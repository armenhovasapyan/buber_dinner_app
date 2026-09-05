using BuberDinner.Application.Menus.Common;

using ErrorOr;

using MediatR;

namespace BuberDinner.Application.Menus.Command.CreateMenu;

public record CreateMenuCommand(
    string HostId,
    string Name,
    string Description,
    List<MenuSectionCommand> Sections
) : IRequest<ErrorOr<MenuResult>>;

public record MenuSectionCommand(
    string Name,
    string Description,
    List<MenuItemCommand> Items
);

public record MenuItemCommand(
    string Name,
    string Description
);
