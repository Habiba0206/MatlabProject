using MatlabProject.Domain.Entities;

namespace MatlabProject.Application.Identity.Services;

public interface IAccessTokenGeneratorService
{
    AccessToken GetToken(User user);

    Guid GetTokenId(string accessToken);
}