using Catalog.UI.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace Catalog.UI.Client.Pages.Products;

public partial class CreateUpdate : ComponentBase
{
    [Inject]
    public required IApiService ApiService { get; set; }
    
    private CreateUpdateVM ProductModel { get; set; } = new ();

    public IEnumerable<CategoryProductVM> Categories { get; set; } = new List<CategoryProductVM>();
    
    [Parameter] 
    public int Id { get; set; }

    public async Task HandleSaveAsync()
    {
        if (Id > 0)
        {
            await ApiService.UpdateAsync($"products/{Id}", ProductModel);
        }
        else
        {
            await ApiService.PostAsync<CreateUpdateVM>("products", ProductModel);
        }
        NavigationManager.NavigateTo("/products");
    }

    protected override async Task OnParametersSetAsync()
    {
        if (Id > 0)
        {
            ProductModel = await ApiService.GetAsync<CreateUpdateVM>($"products/{Id}");
        }
    }

    protected override async Task OnInitializedAsync()
    {
        await LoadCategoriesAsync();
    }

    private async Task LoadCategoriesAsync()
    {
        var data = await ApiService.GetAsync<IEnumerable<CategoryProductVM>>("categories");
        Categories = data;
    }
}