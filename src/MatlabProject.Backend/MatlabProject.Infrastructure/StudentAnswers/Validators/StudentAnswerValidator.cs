using FluentValidation;
using MatlabProject.Domain.Entities;
using MatlabProject.Domain.Enums;

namespace MatlabProject.Infrastructure.StudentAnswers.Validators;
public class StudentAnswerValidator : AbstractValidator<StudentAnswer>
{
    public StudentAnswerValidator()
    {
        RuleSet(
            EntityEvent.OnCreate.ToString(),
            () =>
            {
                RuleFor(answer => answer.QuestionId).NotEqual(Guid.Empty);
                RuleFor(answer => answer.TestResultId).NotEqual(Guid.Empty);
                RuleFor(answer => answer.SelectedAnswer).NotEmpty().MinimumLength(2);
            });

        RuleSet(
            EntityEvent.OnUpdate.ToString(),
            () =>
            {
                RuleFor(answer => answer.SelectedAnswer).NotEmpty().MinimumLength(2);
            });
    }
}
