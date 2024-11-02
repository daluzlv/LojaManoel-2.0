using Microsoft.AspNetCore.Mvc;

namespace Loja_Manoel.Controllers;

[ApiController]
[Route("packing")]
public class PackingController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok("Hello World!");
}