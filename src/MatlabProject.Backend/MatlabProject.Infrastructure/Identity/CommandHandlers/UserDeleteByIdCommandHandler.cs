using MatlabProject.Application.Identity.Commands;
using MatlabProject.Application.Identity.Services;
using MatlabProject.Domain.Common.Commands;

namespace MatlabProject.Infrastructure.Identity.CommandHandlers;

public class UserDeleteByIdCommandHandler(
    IUserService userService)
    : ICommandHandler<UserDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(UserDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await userService.DeleteByIdAsync(request.UserId, cancellationToken: cancellationToken);

        return result is not null;
    }
}
