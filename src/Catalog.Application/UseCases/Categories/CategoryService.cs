using Catalog.Application.UseCases.Categories.ListAll;
using Catalog.Domain.Contracts.Repositories;

namespace Catalog.Application.UseCases.Categories;

public class CategoryService (ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task<IEnumerable<CategoryResponse>> Handle(ListAllCategoryQuery request, CancellationToken cancellationToken = default)
    {
        var categories = await categoryRepository.GetAllAsync(cancellationToken);
        return categories.Select(x=>x.ToResponse());
    }
}