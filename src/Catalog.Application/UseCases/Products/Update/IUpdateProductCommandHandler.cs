using Catalog.Application.Contracts;

namespace Catalog.Application.UseCases.Products.Update;

public interface IUpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>;