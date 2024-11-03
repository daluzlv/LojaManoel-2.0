using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("packing")]
public class PackingController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok("Hello World!");
}