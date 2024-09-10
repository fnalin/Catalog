using Catalog.Application.UseCases.Products.Create;
using Catalog.Application.UseCases.Products.Delete;
using Catalog.Application.UseCases.Products.GetById;
using Catalog.Application.UseCases.Products.ListAll;
using Catalog.Application.UseCases.Products.Update;
using Catalog.Domain.Contracts.Infra;
using Catalog.Domain.Contracts.Repositories;
using Catalog.Domain.Entities;

namespace Catalog.Application.UseCases.Products;

public class ProductService (IProductRepository productRepository, IUnitOfWork uow) : IProductService
{
    public async Task<IEnumerable<ProductResponse>> Handle(ListAllProductQuery request, CancellationToken cancellationToken = default)
    {
        var products = await productRepository.GetAllAsync(cancellationToken);
        return products.Select(x => x.ToResponse());
    }

    public async Task<ProductResponse> Handle(GetByIdProductQuery request, CancellationToken cancellationToken = default)
    {
        var product = await productRepository.GetByIdAsync(request.Id, cancellationToken);
        return product.ToResponse();
    }

    public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken = default)
    {
        var product = new Product(request.Name!, request.Price, (int)request.CategoryId!);
        await productRepository.AddAsync(product, cancellationToken);
        await uow.CommitAsync(cancellationToken);
        return product.ToResponse();
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken = default)
    {
        var product = await productRepository.GetByIdAsync(request.Id, cancellationToken);
        product.Update(request.Name!, (decimal)request.Price!);
        await productRepository.UpdateAsync(product, cancellationToken);
        await uow.CommitAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken = default)
    {
        var product = await productRepository.GetByIdAsync(request.Id, cancellationToken);
        await productRepository.DeleteAsync(product, cancellationToken);
        await uow.CommitAsync(cancellationToken);
        return true;
    }
}