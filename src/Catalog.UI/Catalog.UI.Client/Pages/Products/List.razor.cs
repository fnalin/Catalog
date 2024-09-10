using Catalog.UI.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Catalog.UI.Client.Pages.Products;

public partial class List : ComponentBase
{
    [Inject]
    public required IApiService ApiService { get; set; }
    
    private IEnumerable<ListVM>? Products { get; set; }
    
    [Inject]
    private IJSRuntime JsRuntime { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadProductsAsync();
    }

    private async Task LoadProductsAsync()
    {
        var data = await ApiService.GetAsync<IEnumerable<ListVM>>("products");
        Products = data;
    }
    
    public async Task DeleteProductAsync(int id)
    {
        bool confirm = await JsRuntime.InvokeAsync<bool>("confirm", "Are you sure?");
        if (!confirm) return;
        await ApiService.DeleteAsync($"products/{id}");
        await LoadProductsAsync();
    }
}