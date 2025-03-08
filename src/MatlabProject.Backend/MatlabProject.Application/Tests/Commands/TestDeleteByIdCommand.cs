using MatlabProject.Domain.Common.Commands;

namespace MatlabProject.Application.Tests.Commands;

public class TestDeleteByIdCommand : ICommand<bool>
{
    public Guid TestId { get; set; }
}
