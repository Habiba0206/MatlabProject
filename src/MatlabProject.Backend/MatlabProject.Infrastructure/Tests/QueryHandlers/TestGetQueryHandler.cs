using AutoMapper;
using MatlabProject.Application.Tests.Models;
using MatlabProject.Application.Tests.Queries;
using MatlabProject.Application.Tests.Services;
using MatlabProject.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace MatlabProject.Infrastructure.Tests.QueryHandlers;

public class TestGetQueryHandler(
    IMapper mapper,
    ITestService testService)
    : IQueryHandler<TestGetQuery, ICollection<TestDto>>
{
    public async Task<ICollection<TestDto>> Handle(TestGetQuery request, CancellationToken cancellationToken)
    {
        var result = await testService.Get(
            request.TestFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<TestDto>>(result);
    }
}