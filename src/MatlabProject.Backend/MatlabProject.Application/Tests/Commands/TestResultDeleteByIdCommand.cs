using MatlabProject.Domain.Common.Commands;

namespace MatlabProject.Application.Tests.Commands;

public class TestResultDeleteByIdCommand : ICommand<bool>
{
    public Guid TestResultId { get; set; }
}
