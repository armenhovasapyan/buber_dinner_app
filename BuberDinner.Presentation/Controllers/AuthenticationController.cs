using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Presentation.Controllers;

[Route("auth")]
[ApiController]
public class AuthenticationController(IAuthenticationService auth) : ControllerBase
{
    [Route("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var result = auth.Register(request.FirstName, request.LastName, request.Email, request.Password);
        var response = new AuthenticationResponse(
            result.User.Id,
            result.User.FirstName,
            result.User.LastName,
            result.User.Email,
            result.Token
        );
        return Ok(response);
    }

    [Route("login")]
    public IActionResult Login(LoginRequest request)
    {
        var result = auth.Login(request.Email, request.Password);
        var response = new AuthenticationResponse(
            result.User.Id,
            result.User.FirstName,
            result.User.LastName,
            result.User.Email,
            result.Token
        );
        return Ok(response);
    }
}
