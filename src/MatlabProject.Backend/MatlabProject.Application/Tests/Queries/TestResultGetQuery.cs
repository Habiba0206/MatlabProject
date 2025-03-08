using MatlabProject.Domain.Common.Queries;
using MatlabProject.Application.Tests.Models;

namespace MatlabProject.Application.Tests.Queries;

public class TestResultGetQuery : IQuery<ICollection<TestResultDto>>
{
    public TestResultFilter TestResultFilter { get; set; }
}
