using Catalog.Application.Contracts;

namespace Catalog.Application.UseCases.Categories.ListAll;

public interface IListAllCategoryQueryHandler : IRequestHandler<ListAllCategoryQuery, IEnumerable<CategoryResponse>>;