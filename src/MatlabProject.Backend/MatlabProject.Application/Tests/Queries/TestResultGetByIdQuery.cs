using MatlabProject.Domain.Common.Queries;
using MatlabProject.Application.Tests.Models;

namespace MatlabProject.Application.Tests.Queries;

public class TestResultGetByIdQuery : IQuery<TestResultDto?>
{
    public Guid TestResultId { get; set; }
}
