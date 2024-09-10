using Catalog.Application.Contracts;

namespace Catalog.Application.UseCases.Products.Create;

public interface ICreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponse>;