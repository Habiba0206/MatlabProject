using MatlabProject.Application.Identity.Services;
using MatlabProject.Domain.Constants;
using System.Security.Authentication;

namespace MatlabProject.Api.Middlewares;

public class AccessTokenValidationMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var accessTokenService = context.RequestServices.GetService<IAccessTokenService>();

        var accessTokenIdValue = context.User.Claims.FirstOrDefault(claim => claim.Type == ClaimConstants.AccessTokenId)?.Value;

        if (accessTokenIdValue != null)
        {
            var accessTokenId = Guid.Parse(accessTokenIdValue);
            _ = await accessTokenService.GetByIdAsync(accessTokenId, context.RequestAborted) ?? throw new AuthenticationException("AccessToken not found");
        }

        await next(context);
    }
}
