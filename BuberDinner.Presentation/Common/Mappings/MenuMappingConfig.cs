using BuberDinner.Application.Menus.Command.CreateMenu;
using BuberDinner.Application.Menus.Common;
using BuberDinner.Contracts.Menus;

using Mapster;

using MenuSectionEntity = BuberDinner.Domain.MenuAggregate.Entities.MenuSection;
using MenuItemEntity = BuberDinner.Domain.MenuAggregate.Entities.MenuItem;

namespace BuberDinner.Presentation.Common.Mappings;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<MenuResult, MenuResponse>()
            .Map(dest => dest.Id, src => src.Menu.Id.Value)
            .Map(dest => dest.Name, src => src.Menu.Name)
            .Map(dest => dest.Description, src => src.Menu.Description)
            .Map(dest => dest.AverageRating, src => src.Menu.AvgRating.Value)
            .Map(dest => dest.HostId, src => src.Menu.HostId.Value)
            .Map(dest => dest.Sections, src => src.Menu.Sections)
            .Map(dest => dest.DinnerIds, src => src.Menu.DinerIds.Select(d => d.Value))
            .Map(dest => dest.MenuReviewIds, src => src.Menu.MenuReviewIds.Select(m => m.Value))
            .Map(dest => dest.CreatedDateTime, src => src.Menu.CreatedDateTime)
            .Map(dest => dest.UpdatedDateTime, src => src.Menu.UpdatedDateTime);

        config.NewConfig<MenuSectionEntity, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Items, src => src.Items);

        config.NewConfig<MenuItemEntity, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}
