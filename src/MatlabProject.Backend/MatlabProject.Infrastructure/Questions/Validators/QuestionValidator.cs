using MatlabProject.Domain.Entities;
using MatlabProject.Domain.Enums;
using FluentValidation;

namespace MatlabProject.Infrastructure.Questions.Validators;

public class QuestionValidator : AbstractValidator<Question>
{
    public QuestionValidator()
    {
        RuleSet(
            EntityEvent.OnCreate.ToString(),
            () =>
            {
                RuleFor(question => question.TestId).NotEqual(Guid.Empty);
                RuleFor(question => question.Text).NotEmpty().MaximumLength(2);
                RuleFor(question => question.CorrectAnswer).NotEmpty().MaximumLength(2);
            });

        RuleSet(
            EntityEvent.OnUpdate.ToString(),
            () =>
            {
                RuleFor(question => question.Text).NotEmpty().MaximumLength(2);
                RuleFor(question => question.CorrectAnswer).NotEmpty().MaximumLength(2);
            });
    }
}
