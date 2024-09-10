using Catalog.Application.Contracts;

namespace Catalog.Application.UseCases.Products.Delete;

public interface IDeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>;