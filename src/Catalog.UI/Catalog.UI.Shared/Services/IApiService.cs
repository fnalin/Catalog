namespace Catalog.UI.Shared.Services;

public interface IApiService
{
    Task<T> GetAsync<T>(string route);
    Task<T> PostAsync<T>(string route, object data);
    Task UpdateAsync(string route, object data);
    Task DeleteAsync(string route);
}