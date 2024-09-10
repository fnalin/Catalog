using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers.v1;


[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[controller]")]
public class TesteController : MainController
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Catalog API v1");
    }
}