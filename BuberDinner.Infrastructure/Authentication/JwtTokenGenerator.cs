using System.Text;

using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Domain.Entities;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastructure.Authentication;

public class JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> options) : IJwtTokenGenerator
{
    public string GenerateToken(User user)
    {
        var claims = new Dictionary<string, object>
        {
            { JwtRegisteredClaimNames.Sub, user.Id.ToString() },
            { JwtRegisteredClaimNames.GivenName, user.FirstName },
            { JwtRegisteredClaimNames.FamilyName, user.LastName },
            { JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString() },
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.Secret)),
            SecurityAlgorithms.HmacSha256
        );

        var securityToken = new SecurityTokenDescriptor
        {
            Issuer = options.Value.Issuer,
            Audience = options.Value.Audience,
            Claims = claims,
            Expires = dateTimeProvider.UtcNow.AddMinutes(options.Value.Expires),
            SigningCredentials = signingCredentials
        };

        var handler = new JsonWebTokenHandler();
        return handler.CreateToken(securityToken);
    }
}
