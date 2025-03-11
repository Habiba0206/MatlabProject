using MatlabProject.Application.Questions.Commands;
using MatlabProject.Application.Questions.Services;
using MatlabProject.Domain.Common.Commands;

namespace MatlabProject.Infrastructure.Questions.CommandHandlers;

public class QuestionDeleteByIdCommandHandler(
    IQuestionService questionService)
    : ICommandHandler<QuestionDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(QuestionDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await questionService.DeleteByIdAsync(request.QuestionId, cancellationToken: cancellationToken);

        return result is not null;
    }
}
