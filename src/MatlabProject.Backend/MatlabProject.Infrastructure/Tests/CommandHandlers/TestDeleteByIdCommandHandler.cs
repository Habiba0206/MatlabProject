using MatlabProject.Application.Tests.Commands;
using MatlabProject.Application.Tests.Services;
using MatlabProject.Domain.Common.Commands;

namespace MatlabProject.Infrastructure.Tests.CommandHandlers;

public class TestDeleteByIdCommandHandler(
    ITestService testService)
    : ICommandHandler<TestDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(TestDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await testService.DeleteByIdAsync(request.TestId, cancellationToken: cancellationToken);

        return result is not null;
    }
}