using AutoMapper;
using MatlabProject.Application.Tests.Models;
using MatlabProject.Application.Tests.Queries;
using MatlabProject.Application.Tests.Services;
using MatlabProject.Domain.Common.Queries;

namespace MatlabProject.Infrastructure.Tests.QueryHandlers;

public class TestGetByIdQueryHandler(
    IMapper mapper,
    ITestService testService)
    : IQueryHandler<TestGetByIdQuery, TestDto>
{
    public async Task<TestDto> Handle(TestGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await testService.GetByIdAsync(request.TestId, cancellationToken: cancellationToken);

        return mapper.Map<TestDto> (result);
    }
}
