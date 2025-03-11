using MatlabProject.Domain.Entities;
using MatlabProject.Domain.Enums;
using FluentValidation;
using static System.Net.Mime.MediaTypeNames;

namespace MatlabProject.Infrastructure.Tests.Validators;
public class TestValidator : AbstractValidator<Test>
{
    public TestValidator()
    {
        RuleFor(test => test.Title).NotEmpty().MinimumLength(2);
    }
}
