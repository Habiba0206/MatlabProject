using AutoMapper;
using MatlabProject.Application.Tests.Commands;
using MatlabProject.Application.Tests.Models;
using MatlabProject.Application.Tests.Services;
using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Entities;

namespace MatlabProject.Infrastructure.Tests.CommandHandlers;

public class TestResultCreateCommandHandler(
    IMapper mapper,
    ITestResultService answerService) : ICommandHandler<TestResultCreateCommand, TestResultDto>
{
    public async Task<TestResultDto> Handle(TestResultCreateCommand request, CancellationToken cancellationToken)
    {
        var answer = mapper.Map<TestResult>(request.TestResultDto);

        var createdTestResult = await answerService.CreateAsync(answer, cancellationToken: cancellationToken);

        return mapper.Map<TestResultDto>(createdTestResult);
    }
}
