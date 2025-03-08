using MatlabProject.Domain.Common.Queries;
using MatlabProject.Application.Tests.Models;

namespace MatlabProject.Application.Tests.Queries;

public class TestGetQuery : IQuery<ICollection<TestDto>>
{
    public TestFilter TestFilter { get; set; }
}
