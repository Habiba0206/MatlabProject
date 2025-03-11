using AutoMapper;
using MatlabProject.Application.Tests.Commands;
using MatlabProject.Application.Tests.Models;
using MatlabProject.Application.Tests.Services;
using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Entities;

namespace MatlabProject.Infrastructure.Tests.CommandHandlers;

public class TestCreateCommandHandler(
    IMapper mapper,
    ITestService testService) : ICommandHandler<TestCreateCommand, TestDto>
{
    public async Task<TestDto> Handle(TestCreateCommand request, CancellationToken cancellationToken)
    {
        var answer = mapper.Map<Test>(request.TestDto);

        var createdTest = await testService.CreateAsync(answer, cancellationToken: cancellationToken);

        return mapper.Map<TestDto>(createdTest);
    }
}
