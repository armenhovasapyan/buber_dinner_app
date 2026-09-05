using BuberDinner.Application.Menus.Common;
using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    List<Menu> ListMenus();

    void Add(Menu menu);

    Menu? GetMenuNyName(string name);
}
