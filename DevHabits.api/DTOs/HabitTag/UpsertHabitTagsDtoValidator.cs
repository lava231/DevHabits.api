using DevHabits.api.Database;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DevHabits.api.DTOs.HabitTag;

public sealed class UpsertHabitTagsDtoValidator
    : AbstractValidator<UpsertHabitTagsDto>
{
    public UpsertHabitTagsDtoValidator(ApplicationDbContext dbContext)
    {
        RuleFor(x => x.TagIds)
            .NotNull()
            .NotEmpty()
            .WithMessage("Tag IDs are required.");

        RuleFor(x => x.TagIds)
            .Must(tagIds => tagIds.Distinct().Count() == tagIds.Count)
            .WithMessage("Duplicate tag IDs are not allowed.");

        RuleFor(x => x.TagIds)
            .MustAsync(async (tagIds, cancellationToken) =>
            {
                int existingCount = await dbContext.Tags
                    .CountAsync(
                        t => tagIds.Contains(t.Id),
                        cancellationToken);

                return existingCount == tagIds.Count;
            })
            .WithMessage("One or more tag IDs are invalid.");
    }
}
