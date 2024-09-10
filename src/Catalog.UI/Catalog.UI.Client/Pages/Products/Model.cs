using System.ComponentModel.DataAnnotations;

namespace Catalog.UI.Client.Pages.Products;

public class ListVM
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public CategoryProductVM Category { get; set; } = null!;
}

public class CategoryProductVM
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}

public class CreateUpdateVM
{
    public int Id { get; set; }
    
    [Required]
    public string? Name { get; set; }
    [Required]
    public decimal? Price { get; set; }
    [Required]
    public int? CategoryId { get; set; }
    
}