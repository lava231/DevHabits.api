using System.Reflection.Metadata.Ecma335;
using Ical.Net;

namespace DevHabits.api.Entities;

public sealed class Habit
{
    public string  Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public HabitType Type { get; set; }
    public Frequency Frequency { get; set; }
    public Target Target { get; set; }
    public HabitStauts Status { get; set; }
    public bool IsArchived { get; set; }
    public DateOnly? EndDate { get; set; }
    public Milestone? Milestone { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
    public DateTime? LastCompletedAtUtc { get; set; }

}

public sealed class Milestone
{
    public int Target { get; set; }
    public int Current { get; set; }
}

public sealed class Target
{
    public int Value { get; set; }
    public string Unit { get; set; }
}

public sealed class Frequency
{
    public FrequencyType Type { get; set; }
    public int TimePerPeriod { get; set; }
}

public enum HabitType
{
    None = 0,
    Binary = 1,
    Measurable = 2,
}

public enum HabitStauts
{
    None = 0,
    Ongoing = 1,
    Completed = 2,
}
