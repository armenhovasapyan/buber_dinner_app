using BuberDinner.Application.Common.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator) : IAuthenticationService
{
    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            "firstName",
            "lastName",
            email,
            "token"
        );
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        Guid userId = Guid.NewGuid();
        var token = jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
        return new AuthenticationResult(
            Guid.NewGuid(),
            firstName,
            lastName,
            email,
            token
        );
    }
}
