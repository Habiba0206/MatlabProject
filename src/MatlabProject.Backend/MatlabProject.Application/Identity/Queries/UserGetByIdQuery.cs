using MatlabProject.Domain.Common.Queries;
using MatlabProject.Application.Identity.Models;

namespace MatlabProject.Application.Identity.Queries;

public class UserGetByIdQuery : IQuery<UserDto?>
{
    public Guid UserId { get; set; }
}
