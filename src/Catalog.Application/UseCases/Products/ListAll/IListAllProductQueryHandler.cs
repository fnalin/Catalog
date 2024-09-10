using Catalog.Application.Contracts;

namespace Catalog.Application.UseCases.Products.ListAll;

public interface IListAllProductQueryHandler : IRequestHandler<ListAllProductQuery, IEnumerable<ProductResponse>>;