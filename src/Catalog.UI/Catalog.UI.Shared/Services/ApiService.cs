using System.Net.Http.Json;

namespace Catalog.UI.Shared.Services;

public class ApiService (IHttpClientFactory clientFactory) : IApiService
{
    private readonly HttpClient _client = clientFactory.CreateClient("CatalogApi");
    
    public async Task<T> GetAsync<T>(string route)
    {
        var data = await _client.GetFromJsonAsync<T>(route);
        return data ?? default!;
    }

    public async Task<T> PostAsync<T>(string route, object data)
    {
        var newObj = await _client.PostAsJsonAsync(route, data);
        return await newObj.Content.ReadFromJsonAsync<T>() ?? default!;
    }

    public async Task UpdateAsync(string route, object data)
    {
        await _client.PutAsJsonAsync(route, data);
    }

    public async Task DeleteAsync(string route)
    {
        await _client.DeleteAsync(route);
    }
}