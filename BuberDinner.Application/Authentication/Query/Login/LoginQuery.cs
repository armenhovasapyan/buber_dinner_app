using BuberDinner.Application.Authentication.Common;

using ErrorOr;

using MediatR;

namespace BuberDinner.Application.Authentication.Query.Login;

public record LoginQuery(
    string Email,
    string Paswword
) : IRequest<ErrorOr<AuthenticationResult>>;
