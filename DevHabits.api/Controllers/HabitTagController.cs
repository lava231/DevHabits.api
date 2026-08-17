using DevHabits.api.Database;
using DevHabits.api.DTOs.HabitTag;
using DevHabits.api.Entities;
using DevHabits.api.Middleware.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevHabits.api.Controllers;

[ApiController]
[Route("habits/{habitId}/tags")]
public class HabitTagController(ApplicationDbContext dbContext) : ControllerBase
{
    [HttpPut]
    public async Task<ActionResult> UpsertHabitTags(string habitId, UpsertHabitTagsDto upsertHabitTagsDto,
        [FromServices] IValidator<UpsertHabitTagsDto> validator)
    {
        await validator.ValidateAndThrowAsync(upsertHabitTagsDto);

        Habit? habit = await dbContext.Habits
            .Include(h => h.HabitTags)
            .FirstOrDefaultAsync(h => h.Id == habitId);

        if(habit == null)
        {
            throw new NotFoundException(nameof(Habit), habitId);
        }

        var currentTagIds = habit.HabitTags.Select(ht => ht.TagId).ToHashSet();
        if (currentTagIds.SetEquals(upsertHabitTagsDto.TagIds))
        {
            return NoContent();
        }

        habit.HabitTags.RemoveAll(ht => !upsertHabitTagsDto.TagIds.Contains(ht.TagId));

        string[] tagIdsToAdd = upsertHabitTagsDto.TagIds.Except(currentTagIds).ToArray();
        habit.HabitTags.AddRange(tagIdsToAdd.Select(tagId => new HabitTag 
        {
            HabitId = habitId,
            TagId = tagId,
            CreatedAtUtc = DateTime.UtcNow
        }));

        await dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{tagId}")]
    public async Task<ActionResult> DeleteHabitTag(string habitId, string tagId)
    {
        HabitTag? habitTag = await dbContext.HabitTags
            .SingleOrDefaultAsync(ht => ht.HabitId == habitId && ht.TagId == tagId);

        if (habitTag == null)
        {
            throw new NotFoundException(
             nameof(HabitTag),
             $"{habitId}:{tagId}");
        }

        dbContext.HabitTags.Remove(habitTag);
        await dbContext.SaveChangesAsync();

        return NoContent();
    }
}
