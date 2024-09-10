using Catalog.Application.UseCases.Products.Create;
using Catalog.Application.UseCases.Products.Delete;
using Catalog.Application.UseCases.Products.GetById;
using Catalog.Application.UseCases.Products.ListAll;
using Catalog.Application.UseCases.Products.Update;

namespace Catalog.Application.UseCases.Products;

public interface IProductService : 
    IListAllProductQueryHandler, IGetByIdProductQueryHandler,
    ICreateProductCommandHandler, IUpdateProductCommandHandler,
    IDeleteProductCommandHandler;