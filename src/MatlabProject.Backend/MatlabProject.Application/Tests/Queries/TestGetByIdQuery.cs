using MatlabProject.Domain.Common.Queries;
using MatlabProject.Application.Tests.Models;

namespace MatlabProject.Application.Tests.Queries;

public class TestGetByIdQuery : IQuery<TestDto?>
{
    public Guid TestId { get; set; }
}
