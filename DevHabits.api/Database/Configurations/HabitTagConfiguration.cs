using DevHabits.api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevHabits.api.Database.Configurations;

public class HabitTagConfiguration : IEntityTypeConfiguration<HabitTag>
{
    public void Configure(EntityTypeBuilder<HabitTag> builder)
    {
        builder.HasKey(ht => new { ht.HabitId, ht.TagId });

        builder.HasOne<Habit>()
            .WithMany(h => h.HabitTags)
            .HasForeignKey(ht => ht.HabitId);
        
        builder.HasOne<Tag>()
            .WithMany()
            .HasForeignKey(ht => ht.TagId);
    }
}
