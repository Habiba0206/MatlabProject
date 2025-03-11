using AutoMapper;
using MatlabProject.Application.Identity.Commands;
using MatlabProject.Application.Identity.Models;
using MatlabProject.Application.Identity.Services;
using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Entities;

namespace MatlabProject.Infrastructure.Identity.CommandHandlers;

public class UserUpdateCommandHandler(
    IMapper mapper,
    IUserService userService) : ICommandHandler<UserUpdateCommand, UserDto>
{
    public async Task<UserDto> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request.UserDto);

        var updatedUser = await userService.UpdateAsync(user, cancellationToken: cancellationToken);

        return mapper.Map<UserDto>(updatedUser);
    }
}
