using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService(
    IJwtTokenGenerator jwtTokenGenerator,
    IUserRepository userRepository) : IAuthenticationService
{
    public AuthenticationResult Login(string email, string password)
    {
        if (userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email doesn't exists.");
        }

        if (user.Password != password)
        {
            throw new Exception("Invalid password.");
        }
        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        if (userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email exists.");
        }

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        userRepository.Add(user);

        var token = jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token
        );
    }
}
