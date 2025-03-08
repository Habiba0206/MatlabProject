using MatlabProject.Domain.Common.Commands;

namespace MatlabProject.Application.Identity.Commands;

public class UserDeleteByIdCommand : ICommand<bool>
{
    public Guid UserId { get; set; }
}
