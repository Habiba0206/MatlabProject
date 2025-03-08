using MatlabProject.Domain.Common.Commands;
using MatlabProject.Application.Tests.Models;

namespace MatlabProject.Application.Tests.Commands;

public class TestResultUpdateCommand : ICommand<TestResultDto>
{
    public TestResultDto TestResultDto { get; set; }
}
