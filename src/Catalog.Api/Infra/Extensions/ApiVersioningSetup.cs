using Asp.Versioning;

namespace Catalog.Api.Infra.Extensions;

public static class ApiVersioningSetup
{
    public static void AddApiVersioningSetup(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = ApiVersion.Default; // 1.0
            options.ReportApiVersions = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new HeaderApiVersionReader("api-version"),
                new QueryStringApiVersionReader("api-version"),
                new UrlSegmentApiVersionReader()
            );
            
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        });
    }
}