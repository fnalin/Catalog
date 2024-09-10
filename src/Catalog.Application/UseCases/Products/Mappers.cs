using Catalog.Domain.Entities;

namespace Catalog.Application.UseCases.Products;

public static class Mappers
{
    public static ProductResponse ToResponse(this Product product)
    {
        return new ProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            CategoryId = product.CategoryId,
            Category = new CategoryProductResponse
            {
                Id = product.CategoryId,
                Name = product.Category?.Name!
            }
        };
    }
}