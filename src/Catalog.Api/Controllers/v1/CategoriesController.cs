using Asp.Versioning;
using Catalog.Application.UseCases.Categories;
using Catalog.Application.UseCases.Categories.ListAll;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers.v1;

[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[controller]")]
public class CategoriesController (ICategoryService service) : MainController
{
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CategoryResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var categories = await service.Handle(new ListAllCategoryQuery(), cancellationToken);
        return Ok(categories);
    }
}