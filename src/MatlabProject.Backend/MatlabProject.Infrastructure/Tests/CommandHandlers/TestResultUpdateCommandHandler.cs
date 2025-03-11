using AutoMapper;
using MatlabProject.Application.Tests.Commands;
using MatlabProject.Application.Tests.Models;
using MatlabProject.Application.Tests.Services;
using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Entities;

namespace MatlabProject.Infrastructure.Tests.CommandHandlers;

public class TestResultUpdateCommandHandler(
    IMapper mapper,
    ITestResultService answerService) : ICommandHandler<TestResultUpdateCommand, TestResultDto>
{
    public async Task<TestResultDto> Handle(TestResultUpdateCommand request, CancellationToken cancellationToken)
    {
        var answer = mapper.Map<TestResult>(request.TestResultDto);

        var createdTestResult = await answerService.UpdateAsync(answer, cancellationToken: cancellationToken);

        return mapper.Map<TestResultDto>(createdTestResult);
    }
}
