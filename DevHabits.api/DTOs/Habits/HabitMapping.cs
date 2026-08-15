using System;
using DevHabits.api.Entities;

namespace DevHabits.api.DTOs.Habits;
internal static class HabitMapping
{

    public static HabitDto ToDto(this Habit habit)
    {
        ArgumentNullException.ThrowIfNull(habit);
        return new HabitDto
        {
            Id = habit.Id,
            Name = habit.Name,
            Description = habit.Description,
            Type = habit.Type,
            Frequency = new FrequencyDto
            {
                Type = habit.Frequency.Type,
                TimePerPeriod = habit.Frequency.TimePerPeriod
            },
            Target = new TargetDto
            {
                Value = habit.Target.Value,
                Unit = habit.Target.Unit
            },
            Status = habit.Status,
            IsArchived = habit.IsArchived,
            EndDate = habit.EndDate,
            Milestone = habit.Milestone != null ? new MilestoneDto
            {
                Target = habit.Milestone.Target,
                Current = habit.Milestone.Current
            } : null,
            CreatedAtUtc = habit.CreatedAtUtc,
            UpdatedAtUtc = habit.UpdatedAtUtc,
            LastCompletedAtUtc = habit.LastCompletedAtUtc
        };
    }
    public static Habit ToEntity(this CreateHabitDto createHabitDto)
    {
        ArgumentNullException.ThrowIfNull(createHabitDto);

        return new Habit
        {
            Id = $"h_{Guid.CreateVersion7()}",
            Name = createHabitDto.Name,
            Description = createHabitDto.Description,
            Type = createHabitDto.Type,
            Frequency = new Frequency
            {
                Type = createHabitDto.Frequency.Type,
                TimePerPeriod = createHabitDto.Frequency.TimePerPeriod
            },
            Target = new Target
            {
                Value = createHabitDto.Target.Value,
                Unit = createHabitDto.Target.Unit
            },
            Status = HabitStatus.Ongoing,
            IsArchived = false,
            EndDate = createHabitDto.EndDate,
            Milestone = createHabitDto.Milestone != null ? new Milestone
            {
                Target = createHabitDto.Milestone.Target,
                Current = createHabitDto.Milestone.Current
            } : null,
            CreatedAtUtc = DateTime.UtcNow
        };
    }

    public static void UpdateFromDto(this Habit habit, UpdateHabitDto dto)
    {
        habit.Name = dto.Name;
        habit.Description = dto.Description;
        habit.Type = dto.Type;
        habit.EndDate = dto.EndDate;

        habit.Frequency = new Frequency
        {
            Type = dto.Frequency.Type,
            TimePerPeriod = dto.Frequency.TimePerPeriod
        };

        habit.Target = new Target
        {
            Value = dto.Target.Value,
            Unit = dto.Target.Unit,
        };

        if (dto.Milestone != null)
        {
            habit.Milestone ??= new Milestone();
            habit.Milestone.Target = dto.Milestone.Target;
        }

        habit.UpdatedAtUtc = DateTime.UtcNow;
    }
}
