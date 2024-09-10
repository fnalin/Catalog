using Catalog.Application.Contracts;

namespace Catalog.Application.UseCases.Products;

public class ProductResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public CategoryProductResponse Category { get; set; } = null!;
}

public class CategoryProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}