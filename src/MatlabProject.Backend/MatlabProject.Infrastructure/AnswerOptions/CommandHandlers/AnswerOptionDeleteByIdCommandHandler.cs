using MatlabProject.Application.AnswerOptions.Commands;
using MatlabProject.Application.AnswerOptions.Services;
using MatlabProject.Domain.Common.Commands;

namespace MatlabProject.Infrastructure.AnswerOptions.CommandHandlers;

public class AnswerOptionDeleteByIdCommandHandler(
    IAnswerOptionService answerOptionService)
    : ICommandHandler<AnswerOptionDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(AnswerOptionDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await answerOptionService.DeleteByIdAsync(request.AnswerOptionId, cancellationToken: cancellationToken);

        return result is not null;
    }
}