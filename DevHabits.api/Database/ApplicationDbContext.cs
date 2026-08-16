using System.Reflection.Metadata.Ecma335;
using DevHabits.api.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevHabits.api.Database;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Habit> Habits { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<HabitTag> HabitTags { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Application);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        SeedData.Seed(modelBuilder);
    }
}
