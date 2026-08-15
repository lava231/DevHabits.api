using DevHabits.api.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevHabits.api.Database;

    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedHabits(modelBuilder);
            SeedFrequencies(modelBuilder);
            SeedTargets(modelBuilder);
            SeedMilestones(modelBuilder);
            SeedTags(modelBuilder);
        }
        private static void SeedHabits(ModelBuilder modelBuilder)
        {
            var habits = new List<Habit>
            {
                new()
                {
                    Id = "habit-001",
                    Name = "Drink Water",
                    Description = "Drink at least 2 liters of water per day",
                    Type = HabitType.Measurable,
                    Status = HabitStatus.Ongoing,
                    IsArchived = false,
                    CreatedAtUtc = new DateTime(
                        2026, 8, 7, 0, 0, 0,
                        DateTimeKind.Utc)
                },

                new()
                {
                    Id = "habit-002",
                    Name = "Read Books",
                    Description = "Read 20 pages every day",
                    Type = HabitType.Measurable,
                    Status = HabitStatus.Ongoing,
                    IsArchived = false,
                    CreatedAtUtc = new DateTime(
                        2026, 8, 7, 0, 0, 0,
                        DateTimeKind.Utc)
                },

                new()
                {
                    Id = "habit-003",
                    Name = "Exercise",
                    Description = "Complete four workouts per week",
                    Type = HabitType.Binary,
                    Status = HabitStatus.Ongoing,
                    IsArchived = false,
                    CreatedAtUtc = new DateTime(
                        2026, 8, 7, 0, 0, 0,
                        DateTimeKind.Utc)
                },

                new()
                {
                    Id = "habit-004",
                    Name = "Meditate",
                    Description = "Meditate for 10 minutes every day",
                    Type = HabitType.Measurable,
                    Status = HabitStatus.Ongoing,
                    IsArchived = false,
                    CreatedAtUtc = new DateTime(
                        2026, 8, 7, 0, 0, 0,
                        DateTimeKind.Utc)
                },

                new()
                {
                    Id = "habit-005",
                    Name = "No Fast Food",
                    Description = "Avoid eating fast food",
                    Type = HabitType.Binary,
                    Status = HabitStatus.Ongoing,
                    IsArchived = false,
                    CreatedAtUtc = new DateTime(
                        2026, 8, 7, 0, 0, 0,
                        DateTimeKind.Utc)
                },

                new()
                {
                    Id = "habit-006",
                    Name = "Practice Coding",
                    Description = "Practice backend development for one hour",
                    Type = HabitType.Measurable,
                    Status = HabitStatus.Ongoing,
                    IsArchived = false,
                    CreatedAtUtc = new DateTime(
                        2026, 8, 7, 0, 0, 0,
                        DateTimeKind.Utc)
                },

                new()
                {
                    Id = "habit-007",
                    Name = "Running",
                    Description = "Run five kilometers three times per week",
                    Type = HabitType.Measurable,
                    Status = HabitStatus.Ongoing,
                    IsArchived = false,
                    CreatedAtUtc = new DateTime(
                        2026, 8, 7, 0, 0, 0,
                        DateTimeKind.Utc)
                },

                new()
                {
                    Id = "habit-008",
                    Name = "Call Family",
                    Description = "Call family twice per week",
                    Type = HabitType.Binary,
                    Status = HabitStatus.Ongoing,
                    IsArchived = false,
                    CreatedAtUtc = new DateTime(
                        2026, 8, 7, 0, 0, 0,
                        DateTimeKind.Utc)
                },

                new()
                {
                    Id = "habit-009",
                    Name = "Complete Course",
                    Description = "Complete a backend development course",
                    Type = HabitType.Binary,
                    Status = HabitStatus.Completed,
                    IsArchived = false,
                    CreatedAtUtc = new DateTime(
                        2026, 6, 28, 0, 0, 0,
                        DateTimeKind.Utc),
                    UpdatedAtUtc = new DateTime(
                        2026, 8, 7, 0, 0, 0,
                        DateTimeKind.Utc),
                    LastCompletedAtUtc = new DateTime(
                        2026, 8, 7, 0, 0, 0,
                        DateTimeKind.Utc)
                },

                new()
                {
                    Id = "habit-010",
                    Name = "Study",
                    Description = "Study two hours every day",
                    Type = HabitType.Measurable,
                    Status = HabitStatus.Ongoing,
                    IsArchived = false,
                    CreatedAtUtc = new DateTime(
                        2026, 8, 7, 0, 0, 0,
                        DateTimeKind.Utc)
                }
            };

            modelBuilder.Entity<Habit>().HasData(habits);
        }
        private static void SeedFrequencies(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Habit>()
                .OwnsOne(h => h.Frequency)
                .HasData(
                    new
                    {
                        HabitId = "habit-001",
                        Type = FrequencyType.Daily,
                        TimePerPeriod = 1
                    },
                    new
                    {
                        HabitId = "habit-002",
                        Type = FrequencyType.Daily,
                        TimePerPeriod = 1
                    },
                    new
                    {
                        HabitId = "habit-003",
                        Type = FrequencyType.Weekly,
                        TimePerPeriod = 4
                    },
                    new
                    {
                        HabitId = "habit-004",
                        Type = FrequencyType.Daily,
                        TimePerPeriod = 1
                    },
                    new
                    {
                        HabitId = "habit-005",
                        Type = FrequencyType.Daily,
                        TimePerPeriod = 1
                    },
                    new
                    {
                        HabitId = "habit-006",
                        Type = FrequencyType.Daily,
                        TimePerPeriod = 1
                    },
                    new
                    {
                        HabitId = "habit-007",
                        Type = FrequencyType.Weekly,
                        TimePerPeriod = 3
                    },
                    new
                    {
                        HabitId = "habit-008",
                        Type = FrequencyType.Weekly,
                        TimePerPeriod = 2
                    },
                    new
                    {
                        HabitId = "habit-009",
                        Type = FrequencyType.Weekly,
                        TimePerPeriod = 5
                    },
                    new
                    {
                        HabitId = "habit-010",
                        Type = FrequencyType.Daily,
                        TimePerPeriod = 1
                    }
                );
        }
        private static void SeedTargets(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Habit>()
                .OwnsOne(h => h.Target)
                .HasData(
                    new { HabitId = "habit-001", Value = 2, Unit = "liters" },
                    new { HabitId = "habit-002", Value = 20, Unit = "pages" },
                    new { HabitId = "habit-003", Value = 1, Unit = "workout" },
                    new { HabitId = "habit-004", Value = 10, Unit = "minutes" },
                    new { HabitId = "habit-005", Value = 1, Unit = "day" },
                    new { HabitId = "habit-006", Value = 60, Unit = "minutes" },
                    new { HabitId = "habit-007", Value = 5, Unit = "km" },
                    new { HabitId = "habit-008", Value = 1, Unit = "call" },
                    new { HabitId = "habit-009", Value = 1, Unit = "lesson" },
                    new { HabitId = "habit-010", Value = 2, Unit = "hours" }
                );
        }
        private static void SeedMilestones(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Habit>()
                .OwnsOne(h => h.Milestone)
                .HasData(
                    new { HabitId = "habit-001", Target = 30, Current = 8 },
                    new { HabitId = "habit-002", Target = 1000, Current = 260 },
                    new { HabitId = "habit-003", Target = 50, Current = 12 },
                    new { HabitId = "habit-004", Target = 30, Current = 5 },
                    new { HabitId = "habit-005", Target = 30, Current = 14 },
                    new { HabitId = "habit-006", Target = 100, Current = 37 },
                    new { HabitId = "habit-007", Target = 100, Current = 25 },
                    new { HabitId = "habit-009", Target = 40, Current = 40 },
                    new { HabitId = "habit-010", Target = 30, Current = 18 }
                );
        }
    private static void SeedTags(ModelBuilder modelBuilder)
    {
        var tags = new List<Tag>
        {
            new()
            {
                Id = "tag-001",
                Name = "Health",
                Description = "Habits related to health and overall wellness",
                CreatedAtUtc = new DateTime(
                    2026, 8, 15, 0, 0, 0,
                    DateTimeKind.Utc)
            },

            new()
            {
                Id = "tag-002",
                Name = "Fitness",
                Description = "Habits related to exercise and physical activity",
                CreatedAtUtc = new DateTime(
                    2026, 8, 15, 0, 0, 0,
                    DateTimeKind.Utc)
            },

            new()
            {
                Id = "tag-003",
                Name = "Learning",
                Description = "Habits related to studying and acquiring knowledge",
                CreatedAtUtc = new DateTime(
                    2026, 8, 15, 0, 0, 0,
                    DateTimeKind.Utc)
            },

            new()
            {
                Id = "tag-004",
                Name = "Productivity",
                Description = "Habits related to productivity and efficiency",
                CreatedAtUtc = new DateTime(
                    2026, 8, 15, 0, 0, 0,
                    DateTimeKind.Utc)
            },

            new()
            {
                Id = "tag-005",
                Name = "Mindfulness",
                Description = "Habits related to mindfulness and mental well-being",
                CreatedAtUtc = new DateTime(
                    2026, 8, 15, 0, 0, 0,
                    DateTimeKind.Utc)
            },

            new()
            {
                Id = "tag-006",
                Name = "Nutrition",
                Description = "Habits related to food and healthy eating",
                CreatedAtUtc = new DateTime(
                    2026, 8, 15, 0, 0, 0,
                    DateTimeKind.Utc)
            },

            new()
            {
                Id = "tag-007",
                Name = "Coding",
                Description = "Habits related to programming and software development",
                CreatedAtUtc = new DateTime(
                    2026, 8, 15, 0, 0, 0,
                    DateTimeKind.Utc)
            },

            new()
            {
                Id = "tag-008",
                Name = "Personal",
                Description = "Habits related to personal growth and development",
                CreatedAtUtc = new DateTime(
                    2026, 8, 15, 0, 0, 0,
                    DateTimeKind.Utc)
            },

            new()
            {
                Id = "tag-009",
                Name = "Social",
                Description = "Habits related to family, friends, and relationships",
                CreatedAtUtc = new DateTime(
                    2026, 8, 15, 0, 0, 0,
                    DateTimeKind.Utc)
            },

            new()
            {
                Id = "tag-010",
                Name = "Finance",
                Description = "Habits related to money and financial management",
                CreatedAtUtc = new DateTime(
                    2026, 8, 15, 0, 0, 0,
                    DateTimeKind.Utc)
            }
        };

        modelBuilder.Entity<Tag>().HasData(tags);
    }
}
