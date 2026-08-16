using DevHabit.Api.DTOs.Tags;
using FluentValidation;

namespace DevHabits.api.DTOs.Tags;

public sealed class CreateTagDtoValidator : AbstractValidator<CreateTagDto>
{
    public CreateTagDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(10).WithMessage("Name cannot exceed 10 characters.")
            .MinimumLength(2).WithMessage("Name must be at least 2 characters.");
        RuleFor(x => x.Description)
            .MaximumLength(80).WithMessage("Description cannot exceed 80 characters.");
    }
}
