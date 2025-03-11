using MatlabProject.Domain.Entities;
using MatlabProject.Domain.Enums;
using FluentValidation;

namespace MatlabProject.Infrastructure.AnswerOptions.Validators;
public class AnswerOptionValidator : AbstractValidator<AnswerOption>
{
    public AnswerOptionValidator()
    {
        RuleSet(
            EntityEvent.OnCreate.ToString(),
            () =>
            {
                RuleFor(answerOption => answerOption.QuestionId).NotEqual(Guid.Empty);
                RuleFor(answerOption => answerOption.Text).NotEmpty().MinimumLength(2);
            });

        RuleSet(
            EntityEvent.OnUpdate.ToString(),
            () =>
            {
                RuleFor(answerOption => answerOption.Text).NotEmpty().MinimumLength(2);
            });
    }
}
