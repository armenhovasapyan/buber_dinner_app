using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Menus.Common;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.Entities;

using ErrorOr;

using MediatR;

namespace BuberDinner.Application.Menus.Command.CreateMenu;

public class CreateMenuCommandHandler(IMenuRepository menuRepository) : IRequestHandler<CreateMenuCommand, ErrorOr<MenuResult>>
{
    public async Task<ErrorOr<MenuResult>> Handle(CreateMenuCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (menuRepository.GetMenuNyName(command.Name) is not null)
        {
            return Errors.Menus.DuplicateMenu;
        }

        var menu = Menu.Create(
            HostId.Create(command.HostId),
            command.Name,
            command.Description,
            command.Sections.ConvertAll(section => MenuSection.Create(
                section.Name,
                section.Description,
                section.Items.ConvertAll(item => MenuItem.Create(
                    item.Name,
                    item.Description
                ))
            ))
        );

        menuRepository.Add(menu);

        return new MenuResult(menu);
    }
}
