using BuberDinner.Application;
using BuberDinner.Infrastructure;
using BuberDinner.Presentation.Errors;
using BuberDinner.Presentation.Filters;

using Microsoft.AspNetCore.Mvc.Infrastructure;

// using BuberDinner.Presentation.Middleware;

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddProblemDetails(options =>
        // Customize default behavior for all responses
        options.CustomizeProblemDetails = context =>
            // Add a custom property to the Extensions dictionary
            context.ProblemDetails.Extensions.TryAdd("environment", "Hello"));

    // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();

    // builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();

    builder.Services.AddOpenApi();
}


var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.MapScalarApiReference();
    }

    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
