using BuberDinner.Presentation.Common.Http;

using ErrorOr;

namespace BuberDinner.Presentation.Common.Errors;

public static class DependencyInjection
{
    public static IServiceCollection AddCustomProblemDetails(this IServiceCollection services)
    {
        services.AddProblemDetails(options =>
            // Customize default behavior for all responses
            options.CustomizeProblemDetails = context =>
            {
                // Add a custom property to the Extensions dictionary
                if (context.HttpContext.Items[HttpContextItemKeys.Errors] is List<Error> errors)
                {
                    context.ProblemDetails.Extensions["errorCodes"] = errors.Select(e => e.Code);
                }
            }
        );

        return services;
    }
}
