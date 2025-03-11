using AutoMapper;
using MatlabProject.Application.Tests.Models;
using MatlabProject.Application.Tests.Queries;
using MatlabProject.Application.Tests.Services;
using MatlabProject.Domain.Common.Queries;

namespace MatlabProject.Infrastructure.Tests.QueryHandlers;

public class TestResultGetByIdQueryHandler(
    IMapper mapper,
    ITestResultService testResultService)
    : IQueryHandler<TestResultGetByIdQuery, TestResultDto>
{
    public async Task<TestResultDto> Handle(TestResultGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await testResultService.GetByIdAsync(request.TestResultId, cancellationToken: cancellationToken);

        return mapper.Map<TestResultDto>(result);
    }
}
