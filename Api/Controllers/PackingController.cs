using Application.Queries.Packing.Handlers;
using Application.Queries.Packing.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("packing")]
public class PackingController(GetPackedProductsQueryHandler handler) : ControllerBase
{
    [HttpPost]
    public IActionResult Get([FromBody] GetPackedProductsQuery query, CancellationToken token) =>
        Ok(handler.Handle(query));
}