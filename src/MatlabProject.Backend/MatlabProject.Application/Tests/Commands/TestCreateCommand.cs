using MatlabProject.Domain.Common.Commands;
using MatlabProject.Application.Tests.Models;

namespace MatlabProject.Application.Tests.Commands;

public record TestCreateCommand : ICommand<TestDto>
{
    public TestDto TestDto { get; set; }
}
