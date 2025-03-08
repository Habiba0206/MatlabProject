using MatlabProject.Domain.Common.Queries;
using MatlabProject.Application.Identity.Models;

namespace MatlabProject.Application.Identity.Queries;

public class UserGetQuery : IQuery<ICollection<UserDto>>
{
    public UserFilter UserFilter { get; set; }
}
