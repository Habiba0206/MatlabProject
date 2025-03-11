using MatlabProject.Application.Tests.Commands;
using MatlabProject.Application.Tests.Services;
using MatlabProject.Domain.Common.Commands;

namespace MatlabProject.Infrastructure.Tests.CommandHandlers;

public class TestResultDeleteByIdCommandHandler(
    ITestResultService answerService)
    : ICommandHandler<TestResultDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(TestResultDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await answerService.DeleteByIdAsync(request.TestResultId, cancellationToken: cancellationToken);

        return result is not null;
    }
}