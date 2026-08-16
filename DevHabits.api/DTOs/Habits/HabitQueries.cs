using System.Linq.Expressions;
using DevHabits.api.Entities;

namespace DevHabits.api.DTOs.Habits;

internal static class HabitQueries
{
    public static Expression<Func<Habit, HabitDto>> HabitToDto()
    {
        return h => new HabitDto
        {
            Id = h.Id,
            Name = h.Name,
            Description = h.Description,
            Type = h.Type,
            Frequency = new FrequencyDto
            {
                Type = h.Frequency.Type,
                TimesPerPeriod = h.Frequency.TimePerPeriod
            },
            Target = new TargetDto
            {
                Value = h.Target.Value,
                Unit = h.Target.Unit
            },
            Status = h.Status,
            IsArchived = h.IsArchived,
            EndDate = h.EndDate,
            Milestone = h.Milestone != null ? new MilestoneDto
            {
                Target = h.Milestone.Target,
                Current = h.Milestone.Current
            } : null,
            CreatedAtUtc = h.CreatedAtUtc,
            UpdatedAtUtc = h.UpdatedAtUtc,
            LastCompletedAtUtc = h.LastCompletedAtUtc
        };
    }

    public static Expression<Func<Habit, HabitWithTagsDto>> HabitToWithTagsDto()
    {
        return h => new HabitWithTagsDto
        {
            Id = h.Id,
            Name = h.Name,
            Description = h.Description,
            Type = h.Type,
            Frequency = new FrequencyDto
            {
                Type = h.Frequency.Type,
                TimesPerPeriod = h.Frequency.TimePerPeriod
            },
            Target = new TargetDto
            {
                Value = h.Target.Value,
                Unit = h.Target.Unit
            },
            Status = h.Status,
            IsArchived = h.IsArchived,
            EndDate = h.EndDate,
            Milestone = h.Milestone != null ? new MilestoneDto
            {
                Target = h.Milestone.Target,
                Current = h.Milestone.Current
            } : null,
            CreatedAtUtc = h.CreatedAtUtc,
            UpdatedAtUtc = h.UpdatedAtUtc,
            LastCompletedAtUtc = h.LastCompletedAtUtc,
            Tags = h.Tags.Select(t => t.Name)
            .ToList()
        };
    }
}
