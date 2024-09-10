using Catalog.UI.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.UI.Shared.Infra.Extensions;

public static class FrontEndSetup
{
    public static void AddFrontEndSetup(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IApiService, ApiService>();
        services.AddHttpClient("CatalogApi", client =>
        {
            var appUri = configuration["APIServer:Url"] ??
                         throw new Exception("API Server URL not found");
            client.BaseAddress = new Uri(appUri);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        });
    }
}