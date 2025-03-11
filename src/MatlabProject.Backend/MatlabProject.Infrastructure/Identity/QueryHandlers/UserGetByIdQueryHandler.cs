using AutoMapper;
using MatlabProject.Application.Identity.Models;
using MatlabProject.Application.Identity.Queries;
using MatlabProject.Application.Identity.Services;
using MatlabProject.Domain.Common.Queries;

namespace MatlabProject.Infrastructure.Identity.QueryHandlers;

public class UserGetByIdQueryHandler(
    IMapper mapper,
    IUserService userService)
    : IQueryHandler<UserGetByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await userService.GetByIdAsync(request.UserId, cancellationToken: cancellationToken);

        return mapper.Map<UserDto>(result);
    }
}
