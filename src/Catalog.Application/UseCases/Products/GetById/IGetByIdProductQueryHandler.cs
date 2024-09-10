using Catalog.Application.Contracts;

namespace Catalog.Application.UseCases.Products.GetById;

public interface IGetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, ProductResponse>;