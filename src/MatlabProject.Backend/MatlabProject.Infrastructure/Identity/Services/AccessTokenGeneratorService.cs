﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MatlabProject.Application.Common.Settings;
using MatlabProject.Application.Identity.Services;
using MatlabProject.Domain.Constants;
using MatlabProject.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MatlabProject.Infrastructure.Identity.Services;

public class AccessTokenGeneratorService(IOptions<JwtSettings> jwtSettings) : IAccessTokenGeneratorService
{
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;

    public AccessToken GetToken(User user)
    {
        var accessToken = new AccessToken
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
        };
        var jwtToken = GetJwtToken(user, accessToken);
        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        accessToken.Token = token;

        return accessToken;
    }

    public Guid GetTokenId(string accessToken)
    {
        var tokenValue = accessToken.Split(' ')[1];
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(tokenValue);
        var tokenId = token.Claims.FirstOrDefault(c => c.Type == ClaimConstants.AccessTokenId)?.Value;

        if (string.IsNullOrEmpty(tokenId))
            throw new ArgumentException("Invalid access token");

        return Guid.Parse(tokenId);
    }

    private JwtSecurityToken GetJwtToken(User user, AccessToken accessToken)
    {
        var claims = GetClaims(user, accessToken);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken(
            _jwtSettings.ValidIssuer,
            _jwtSettings.ValidAudience,
            claims,
            DateTime.UtcNow,
            DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationTimeInMinutes),
            credentials
        );
    }

    private List<Claim> GetClaims(User user, AccessToken accessToken)
    {
        return new List<Claim>
        {
            new(ClaimTypes.Email, user.EmailAddress),
            new(ClaimTypes.Role, user.Role.ToString()),
            new(ClaimConstants.UserId, user.Id.ToString()),
            new(ClaimConstants.AccessTokenId, accessToken.Id.ToString())
        };
    }
}