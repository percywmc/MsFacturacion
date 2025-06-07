using Microsoft.AspNetCore.Mvc;

namespace MsFacturacion.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BillingController : ControllerBase
{
    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok(new { message = "Billing service is running" });
    }
}
