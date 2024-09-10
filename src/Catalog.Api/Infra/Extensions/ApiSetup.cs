using Catalog.Api.Infra.Filters;
using Catalog.CrossCutting;
using Microsoft.Net.Http.Headers;

namespace Catalog.Api.Infra.Extensions;

public static class ApiSetup
{
    public static void AddApiSetup(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers(options =>
        {
            options.Filters.Add(typeof(CustomExceptionFilter));
        });
        services.AddApiVersioningSetup();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerSetup();
        services.AddApiHealthChecks(configuration);
        services.AddCrossCuttingDependencies(configuration);
        services.AddCors();
    }
    
    public static void UseApiSetup(this WebApplication app)
    {
        app.UseCors(policy =>
        {
            policy.WithOrigins("https://localhost:7196", "http://localhost:5172")
                .AllowAnyMethod()
                .WithHeaders(HeaderNames.ContentType);
        });
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerSetup();
            app.UseCrossCuttingDependencies();
        }

        app.UseApiHealthChecks();
        app.MapControllers();
    }
}