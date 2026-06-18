
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Scalar.AspNetCore;
using WrightBrothersApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks()
    .AddCheck("CruisingAltitudeCheck", () =>
    {
        var cruisingAltitude = int.Parse(Environment.GetEnvironmentVariable("CRUISING_ALTITUDE") ?? "0");

        if (cruisingAltitude >= 0)
        {
            return HealthCheckResult.Healthy("The application is cruising smoothly at optimal altitude.");
        }
        else
        {
            return HealthCheckResult.Unhealthy("The application is facing a system failure and needs immediate attention.");
        }
    });
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddSingleton<IFlightRepository, FlightRepository>();
builder.Services.AddSingleton<IPlaneRepository, PlaneRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }
    );
});

var app = builder.Build();

// Add the following code to map the health checks to an endpoint
app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
        return;
    }
    await next();
});

app.Run();

public partial class Program { }
