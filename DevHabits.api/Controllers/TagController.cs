using System.ComponentModel.DataAnnotations;
using DevHabit.Api.DTOs.Habits;
using DevHabit.Api.DTOs.Tags;
using DevHabits.api.Database;
using DevHabits.api.DTOs.Tags;
using DevHabits.api.Entities;
using DevHabits.api.Middleware.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DevHabits.api.Controllers;

[ApiController]
[Route("tags")]
public class TagController(ApplicationDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<TagsCollectionDto>> GetTags()
    {
        List<TagDto> tagsDto = await dbContext.Tags.Select(TagQueries.ProjectToDto()).ToListAsync();

        var tagsCollection = new TagsCollectionDto
        {
            Items = tagsDto
        };

        return Ok(tagsCollection);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TagDto>> GetTag(string id)
    {
        var tag = await dbContext.Tags.Select(TagQueries.ProjectToDto()).FirstOrDefaultAsync(t => t.Id == id);

        if (tag == null)
        {
            throw new NotFoundException(nameof(Tag), id);
        }

        return Ok(tag);
    }

    [HttpPost]
    public async Task<ActionResult<TagDto>> CreateTag(CreateTagDto createTagDto,
        IValidator<CreateTagDto> validator)
    {
        await validator.ValidateAndThrowAsync(createTagDto);

        Tag tag = createTagDto.ToEntity();

        dbContext.Tags.Add(tag);
        await dbContext.SaveChangesAsync();

        TagDto tagDto = tag.ToDto();
        
        return CreatedAtAction(nameof(GetTag), new { id = tagDto.Id }, tagDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TagDto>> UpdateTag(string id, UpdateTagDto updateTagDto,
        [FromServices] IValidator<UpdateTagDto> validator)
    {
        await validator.ValidateAndThrowAsync(updateTagDto);

        Tag? tag = await dbContext.Tags.FirstOrDefaultAsync(t => t.Id == id);

        if (tag == null)
        {
            throw new NotFoundException(nameof(Tag), id);
        }

        tag.UpdateFromDto(updateTagDto);
        await dbContext.SaveChangesAsync();

        TagDto tagDto = tag.ToDto();

        return Ok(tagDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTag(string id)
    {
        var tag = await dbContext.Tags.FirstOrDefaultAsync(t => t.Id == id);

        if (tag == null)
        {
            throw new NotFoundException(nameof(Tag), id);
        }

        dbContext.Tags.Remove(tag);
        await dbContext.SaveChangesAsync();

        return NoContent();
    }
}
