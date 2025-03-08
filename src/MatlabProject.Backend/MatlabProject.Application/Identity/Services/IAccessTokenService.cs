using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Entities;

namespace MatlabProject.Application.Identity.Services;

public interface IAccessTokenService
{
    ValueTask<AccessToken> CreateAsync(
        AccessToken accessToken,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
    ValueTask<AccessToken?> GetByIdAsync(
        Guid accessTokeId,
        CancellationToken cancellationToken = default);
    ValueTask RevokeAsync(
        Guid accessTokenId,
        CancellationToken cancellationToken = default);
}
