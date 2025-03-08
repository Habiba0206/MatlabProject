using MatlabProject.Domain.Common.Commands;
using MatlabProject.Application.Tests.Models;

namespace MatlabProject.Application.Tests.Commands;

public class TestUpdateCommand : ICommand<TestDto>
{
    public TestDto TestDto { get; set; }
}
