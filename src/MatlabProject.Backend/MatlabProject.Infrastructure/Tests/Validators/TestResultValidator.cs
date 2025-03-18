using MatlabProject.Domain.Entities;
using MatlabProject.Domain.Enums;
using FluentValidation;

namespace MatlabProject.Infrastructure.Tests.Validators;
public class TestResultValidator : AbstractValidator<TestResult>
{
    public TestResultValidator()
    {
        RuleFor(testResult => testResult.UserId).NotEqual(Guid.Empty);
        RuleFor(testResult => testResult.TestId).NotEqual(Guid.Empty);
        RuleFor(testResult => testResult.StartTime).LessThan(testResult => testResult.EndTime);
        RuleFor(testResult => testResult.EndTime).GreaterThan(testResult => testResult.StartTime);
    }
}
