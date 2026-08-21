using System.Text;

using BuberDinner.Application.Common.Authentication;
using BuberDinner.Application.Common.Services;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastructure.Authentication;

public class JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> options) : IJwtTokenGenerator
{
    public string GenerateToken(Guid userId, string firstName, string lastName)
    {
        var claims = new Dictionary<string, object>
        {
            { JwtRegisteredClaimNames.Sub, userId.ToString() },
            { JwtRegisteredClaimNames.GivenName, firstName },
            { JwtRegisteredClaimNames.FamilyName, lastName },
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
