using MatlabProject.Domain.Common.Commands;
using MatlabProject.Application.Tests.Models;

namespace MatlabProject.Application.Tests.Commands;

public record TestResultCreateCommand : ICommand<TestResultDto>
{
    public TestResultDto TestResultDto { get; set; }
}
