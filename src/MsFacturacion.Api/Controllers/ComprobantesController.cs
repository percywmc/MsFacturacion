using Microsoft.AspNetCore.Mvc;
using MsFacturacion.Api.Application.Comprobantes;
using MsFacturacion.Api.Application.Comprobantes.DTOs;

namespace MsFacturacion.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComprobantesController : ControllerBase
{
    private readonly IComprobanteService _service;

    public ComprobantesController(IComprobanteService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Crear(CreateComprobanteDto dto, CancellationToken cancellationToken)
    {
        var result = await _service.CreateAsync(dto, cancellationToken);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = result.Id }, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(Guid id, CancellationToken cancellationToken)
    {
        var result = await _service.GetByIdAsync(id, cancellationToken);
        if (result is null) return NotFound();
        return Ok(result);
    }
}
