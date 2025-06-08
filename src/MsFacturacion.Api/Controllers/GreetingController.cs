using Microsoft.AspNetCore.Mvc;
using MsFacturacion.Api.Application;

namespace MsFacturacion.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GreetingController : ControllerBase
{
    private readonly IGreetingService _service;

    public GreetingController(IGreetingService service)
    {
        _service = service;
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        var greeting = _service.GetGreeting();
        return Ok(greeting);
    }
}
