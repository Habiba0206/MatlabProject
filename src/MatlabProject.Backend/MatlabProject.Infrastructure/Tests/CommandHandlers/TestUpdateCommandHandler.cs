using AutoMapper;
using MatlabProject.Application.Tests.Commands;
using MatlabProject.Application.Tests.Models;
using MatlabProject.Application.Tests.Services;
using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Entities;

namespace MatlabProject.Infrastructure.Tests.CommandHandlers;

public class TestUpdateCommandHandler(
    IMapper mapper,
    ITestService testService) : ICommandHandler<TestUpdateCommand, TestDto>
{
    public async Task<TestDto> Handle(TestUpdateCommand request, CancellationToken cancellationToken)
    {
        var test = mapper.Map<Test>(request.TestDto);

        var createdTest = await testService.UpdateAsync(test, cancellationToken: cancellationToken);

        return mapper.Map<TestDto>(createdTest);
    }
}
