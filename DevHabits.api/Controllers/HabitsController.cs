using System.Linq.Expressions;
using Azure;
using DevHabits.api.Database;
using DevHabits.api.DTOs.Habits;
using DevHabits.api.Entities;
using DevHabits.api.Middleware.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DevHabits.api.Controllers;

[ApiController]
[Route("habits")]
public class HabitsController(ApplicationDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<HabitsCollectionDto>> GetHabits()
    {
        List<HabitDto> habits = await dbContext.Habits.Select(HabitQueries.HabitToDto()).ToListAsync();

        var habitsCollectionDto = new HabitsCollectionDto
        {
            Items = habits
        };
        return Ok(habitsCollectionDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HabitWithTagsDto>> GetHabitById(string id)
    {
        HabitWithTagsDto? habit = await dbContext.Habits
            .Where(h => h.Id == id)
            .Select(HabitQueries.HabitToWithTagsDto())
            .FirstOrDefaultAsync();

        if (habit == null)
        {
            throw new NotFoundException(nameof(habit), id);
        }

        return Ok(habit);
    }

    [HttpPost]
    public async Task<ActionResult<HabitDto>> CreateHabit(CreateHabitDto createHabitDto, 
        IValidator<CreateHabitDto> validator)
    {
        await validator.ValidateAndThrowAsync(createHabitDto);

        Habit habit = createHabitDto.ToEntity();

        dbContext.Habits.Add(habit);
        await dbContext.SaveChangesAsync();
        
        HabitDto habitDto = habit.ToDto();

        return CreatedAtAction(nameof(GetHabitById), new { id = habitDto.Id }, habitDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateHabit( string id,[FromBody] UpdateHabitDto updateHabitDto,
        [FromServices] IValidator<UpdateHabitDto> validator)
    {
        await validator.ValidateAndThrowAsync(updateHabitDto);

        var habit = await dbContext.Habits.FirstOrDefaultAsync(h =>  h.Id == id);

        if (habit == null)
        {
            throw new NotFoundException(nameof(Habit), id);
        }


        habit.UpdateFromDto(updateHabitDto);
        
        await dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> PatchHabit(string id, JsonPatchDocument<HabitDto> patchDocument,
        [FromServices] IValidator<HabitDto> validator)
    {
        var habit = await dbContext.Habits.FirstOrDefaultAsync(h => h.Id == id);

        if (habit == null)
        {
            throw new NotFoundException(nameof(Habit), id);
        }

        HabitDto habitDto = habit.ToDto();

        patchDocument.ApplyTo(habitDto, ModelState);

        if (!TryValidateModel(habitDto))
        {
            return ValidationProblem(ModelState);
        }

        await validator.ValidateAndThrowAsync(habitDto);
        
        habit.Name = habitDto.Name;
        habit.Description = habitDto.Description;
        habit.UpdatedAtUtc = DateTime.UtcNow;

        await dbContext.SaveChangesAsync();

        return NoContent();

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteHabit(string id)
    {
        Habit? habit = await dbContext.Habits.FirstOrDefaultAsync(h => h.Id == id);

        if (habit == null)
        {
            throw new NotFoundException(nameof(Habit), id);
        }

        dbContext.Habits.Remove(habit);
        await dbContext.SaveChangesAsync();

        return NoContent();
    }
}
