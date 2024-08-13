using FluentValidation;
using cinema_api.Dtos;

public class CreateFunctionDtoValidator : AbstractValidator<CreateFunctionDto>
{
    public CreateFunctionDtoValidator()
    {
        RuleFor(x => x.Date)
            .Must(date => date != DateOnly.MinValue)
            .WithMessage("Date is required.");

        RuleFor(x => x.ScheduleHour)
            .Must(hour => hour != TimeOnly.MinValue)
            .NotEmpty()
            .WithMessage("ScheduleHour is required.");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than zero.");

        RuleFor(x => x.MovieId)
            .GreaterThan(0)
            .WithMessage("MovieId is required and must be a positive integer.");
    }
}

public class UpdateFunctionDtoValidator : AbstractValidator<UpdateFunctionDto>
{
    public UpdateFunctionDtoValidator()
    {
        RuleFor(x => x.Date)
            .Must(date => date != DateOnly.MinValue)
            .NotEmpty()
            .WithMessage("Date is required.");

        RuleFor(x => x.ScheduleHour)
            .Must(hour => hour != TimeOnly.MinValue)
            .NotEmpty()
            .WithMessage("ScheduleHour is required.");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than zero.");

        RuleFor(x => x.MovieId)
            .GreaterThan(0)
            .WithMessage("MovieId is required");
    }
}