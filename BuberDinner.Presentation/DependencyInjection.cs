using BuberDinner.Presentation.Common.Errors;
using BuberDinner.Presentation.Common.Mappings;

namespace BuberDinner.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();

        services
        .AddCustomProblemDetails()
        .AddMappings();

        return services;
    }
}
