using Asp.Versioning;
using Catalog.Application.UseCases.Categories;
using Catalog.Application.UseCases.Categories.ListAll;
using Catalog.Application.UseCases.Products;
using Catalog.Application.UseCases.Products.Create;
using Catalog.Application.UseCases.Products.Delete;
using Catalog.Application.UseCases.Products.GetById;
using Catalog.Application.UseCases.Products.ListAll;
using Catalog.Application.UseCases.Products.Update;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers.v1;

[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[controller]")]
public class ProductsController (IProductService service): MainController
{
    
    [HttpGet("{id:int}", Name = nameof(GetByIdAsync))]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductResponse>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var product = await service.Handle(new GetByIdProductQuery(id), cancellationToken);
        return Ok(product);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProductResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ProductResponse>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var products = await service.Handle(new ListAllProductQuery(), cancellationToken);
        return Ok(products);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductResponse>> CreateAsync(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var newProduct = await service.Handle(command, cancellationToken);
        return CreatedAtRoute(nameof(GetByIdAsync), new { id = newProduct.Id }, newProduct);
    }
    
    [HttpPut("{id:int}")]
    [ProducesResponseType( StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateAsync(int id, UpdateProductCommand command, CancellationToken cancellationToken)
    {
        command.Id = id;
        _ = await service.Handle(command, cancellationToken);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        _ = await service.Handle(new DeleteProductCommand(id), cancellationToken);
        return NoContent();
    }
    
    
}