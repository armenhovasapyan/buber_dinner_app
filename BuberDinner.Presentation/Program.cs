using BuberDinner.Application;
using BuberDinner.Infrastructure;
using BuberDinner.Presentation;

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration)
        .AddCustomProblemDetails();

    builder.Services.AddControllers();

    builder.Services.AddOpenApi();
}


var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.MapScalarApiReference();
    }

    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
