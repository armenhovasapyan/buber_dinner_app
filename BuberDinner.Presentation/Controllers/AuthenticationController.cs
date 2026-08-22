using BuberDinner.Application.Authentication.Command.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Query.Login;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;

using ErrorOr;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Presentation.Controllers;

[Route("auth")]
public class AuthenticationController(ISender mediator) : ApiController

{
    [Route("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> result = await mediator.Send(new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password));
        return result.Match(
            result => Ok(MapAuthResult(result)),
            errors => Problem(errors)
        );
    }

    [Route("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        ErrorOr<AuthenticationResult> result = await mediator.Send(new LoginQuery(request.Email, request.Password));
        if (result.IsError && result.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: result.FirstError.Description
            );
        }

        return result.Match(
            result => Ok(MapAuthResult(result)),
            errors => Problem(errors)
        );
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult result)
    {
        return new AuthenticationResponse(
            result.User.Id,
            result.User.FirstName,
            result.User.LastName,
            result.User.Email,
            result.Token
        );
    }
}
