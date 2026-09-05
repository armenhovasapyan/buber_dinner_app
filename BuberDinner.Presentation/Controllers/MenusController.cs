using BuberDinner.Application.Menus.Command.CreateMenu;
using BuberDinner.Application.Menus.Common;
using BuberDinner.Contracts.Menus;

using ErrorOr;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Presentation.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenusController(ISender mediator, IMapper mapper) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateManu(CreateMenuRequest request, string hostId)
    {
        ErrorOr<MenuResult> result = await mediator.Send(mapper.Map<CreateMenuCommand>((request, hostId)));
        return result.Match(
            result => Ok(mapper.Map<MenuResponse>(result)),
            errors => Problem(errors)
        );
    }
}
