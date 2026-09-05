using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = [];

    public List<Menu> ListMenus()
    {
        return _menus;
    }

    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }

    public Menu? GetMenuNyName(string name)
    {
        return _menus.SingleOrDefault(m => m.Name == name);
    }
}
