using Catalog.Domain.Entities;

namespace Catalog.Application.UseCases.Categories;

public static class Mappers
{
    public static CategoryResponse ToResponse(this Category category)
    {
        return new CategoryResponse
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}