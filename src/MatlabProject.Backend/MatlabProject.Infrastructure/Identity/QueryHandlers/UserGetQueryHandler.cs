using AutoMapper;
using MatlabProject.Application.Identity.Models;
using MatlabProject.Application.Identity.Queries;
using MatlabProject.Application.Identity.Services;
using MatlabProject.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace MatlabProject.Infrastructure.Identity.QueryHandlers;

public class UserGetQueryHandler(
    IMapper mapper,
    IUserService userService)
    : IQueryHandler<UserGetQuery, ICollection<UserDto>>
{
    public async Task<ICollection<UserDto>> Handle(UserGetQuery request, CancellationToken cancellationToken)
    {
        var result = await userService.Get(
            request.UserFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<UserDto>>(result);
    }
}
