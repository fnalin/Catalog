using System.Text.Json;
using Catalog.Domain.Exceptions.Infra;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Catalog.Api.Infra.Extensions;

public static class ApiHealthChecksSetup
{
    
    public static void AddApiHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddHealthChecks()
            .AddSqlServer(
                connectionString:
                    configuration.GetConnectionString("DbConnection") ??
                        throw new ConnStringNullReferenceException("DbConnection not found"),
                healthQuery: "SELECT 1;",
                name: "SqlServer Check",
                failureStatus: HealthStatus.Unhealthy,
                tags: new[] { "db", "sql" },
                timeout: TimeSpan.FromSeconds(10)
            );

    }
    
    public static void UseApiHealthChecks(this IApplicationBuilder app)
    {
        app.UseHealthChecks("/health", new HealthCheckOptions
        {
            Predicate = _ => false,
        });
        
        app.UseHealthChecks("/health/tags/db", new HealthCheckOptions
        {
            Predicate = registration => registration.Tags.Contains("db")
        });
        
        app.UseHealthChecks("/health/details", new HealthCheckOptions
        {
            ResponseWriter = async (context, report) =>
            {
                context.Response.ContentType = "application/json";
                var result = JsonSerializer.Serialize(
                    new
                    {
                        status = report.Status.ToString(),
                        totalDuration = report.TotalDuration.TotalSeconds.ToString("0:0.00"),
                        components = report.Entries
                            .Select(e => new
                            {
                                name = e.Key, 
                                duration = e.Value.Duration.TotalSeconds.ToString("0:0.00"),
                                status = Enum.GetName(typeof(HealthStatus), e.Value.Status),
                                exception = e.Value.Exception?.Message,
                                description = e.Value.Description
                            })
                    });
                    
                await context.Response.WriteAsync(result);
            }
        });

    }
    
}