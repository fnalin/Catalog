using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers.v2;

[ApiVersion(2)]
[Route("api/v{version:apiVersion}/[controller]")]
public class TesteController : MainController
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Catalog API - v2");
    }
}