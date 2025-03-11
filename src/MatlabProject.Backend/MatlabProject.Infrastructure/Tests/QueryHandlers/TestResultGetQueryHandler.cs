using AutoMapper;
using MatlabProject.Application.Tests.Models;
using MatlabProject.Application.Tests.Queries;
using MatlabProject.Application.Tests.Services;
using MatlabProject.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace MatlabProject.Infrastructure.Tests.QueryHandlers;

public class TestResultGetQueryHandler(
    IMapper mapper,
    ITestResultService testResultService)
    : IQueryHandler<TestResultGetQuery, ICollection<TestResultDto>>
{
    public async Task<ICollection<TestResultDto>> Handle(TestResultGetQuery request, CancellationToken cancellationToken)
    {
        var result = await testResultService.Get(
            request.TestResultFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<TestResultDto>>(result);
    }
}
