using DevHabits.api.DTOs.Habits;
using FluentValidation;

public sealed class HabitDtoValidator : AbstractValidator<HabitDto>
{
    public HabitDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(15);

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .When(x => x.Description is not null);
    }
}
