using DevHabits.api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevHabits.api.Database.Configurations;

public class HabitConfiguration : IEntityTypeConfiguration<Habit>
{
    public void Configure(EntityTypeBuilder<Habit> builder)
    {
        builder.HasKey(h => h.Id);
        
        builder.HasIndex(h => h.Name);

        builder.Property(h => h.Id).HasMaxLength(500);
        builder.Property(h => h.Name).HasMaxLength(100);
        builder.Property(h => h.Description).HasMaxLength(500);

        builder.OwnsOne(h => h.Frequency);
        builder.OwnsOne(h => h.Target, targetbuilder =>
        {
            targetbuilder.Property(t => t.Unit).HasMaxLength(500);
        });
        builder.OwnsOne(h => h.Milestone);
    }
}
