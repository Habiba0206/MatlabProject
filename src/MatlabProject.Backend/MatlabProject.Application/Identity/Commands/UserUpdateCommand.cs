using MatlabProject.Domain.Common.Commands;
using MatlabProject.Application.Identity.Models;

namespace MatlabProject.Application.Identity.Commands;

public class UserUpdateCommand : ICommand<UserDto>
{
    public UserDto UserDto { get; set; }
}
