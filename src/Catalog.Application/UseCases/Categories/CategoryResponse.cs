using Catalog.Application.Contracts;

namespace Catalog.Application.UseCases.Categories;

public class CategoryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}