using MatlabProject.Domain.Entities;
using MatlabProject.Domain.Enums;
using FluentValidation;
using static System.Net.Mime.MediaTypeNames;

namespace MatlabProject.Infrastructure.Tests.Validators;
public class TestValidator : AbstractValidator<Test>
{
    public TestValidator()
    {
        RuleSet(
            EntityEvent.OnCreate.ToString(),
            () =>
            {
                RuleFor(test => test.UserId).NotEqual(Guid.Empty);
                RuleFor(test => test.Title).NotEmpty().MinimumLength(2);
                RuleFor(test => test.Description).NotEmpty().MinimumLength(2);
                RuleFor(test => test.DurationMinutes).GreaterThan(1);
            }
        );

        RuleSet(
            EntityEvent.OnUpdate.ToString(),
            () =>
            {
                RuleFor(test => test.Title).NotEmpty().MinimumLength(2);
                RuleFor(test => test.Description).NotEmpty().MinimumLength(2);
                RuleFor(test => test.DurationMinutes).GreaterThan(1);
            }
        );
    }
}
