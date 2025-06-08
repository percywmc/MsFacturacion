using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using MsFacturacion.Api.Application;
using MsFacturacion.Api.Domain;

namespace MsFacturacion.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BillingController : ControllerBase
{
    private readonly ComprobanteService _service;

    public BillingController(ComprobanteService service)
    {
        _service = service;
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok(new { message = "Billing service is running" });
    }

    /// <summary>
    /// Emite un comprobante de pago.
    /// </summary>
    [HttpPost("comprobantes")]
    public IActionResult EmitirComprobante([FromBody] ComprobanteDto dto)
    {
        var comprobante = new Comprobante
        {
            Tipo = dto.Tipo,
            RucEmisor = dto.RucEmisor,
            RazonSocialEmisor = dto.RazonSocialEmisor,
            Monto = dto.Monto
        };

        var resultado = _service.Emitir(comprobante);
        return CreatedAtAction(nameof(ObtenerComprobante), new { id = resultado.Id }, resultado);
    }

    /// <summary>
    /// Obtiene un comprobante por su identificador.
    /// </summary>
    [HttpGet("comprobantes/{id}")]
    public IActionResult ObtenerComprobante(Guid id)
    {
        var comprobante = _service.ObtenerPorId(id);
        if (comprobante is null)
        {
            return NotFound();
        }
        return Ok(comprobante);
    }
}

/// <summary>
/// DTO de entrada para crear comprobantes.
/// </summary>
public record ComprobanteDto(
    [Required] TipoComprobante Tipo,
    [Required, RegularExpression(@"^\d{11}$")] string RucEmisor,
    [Required, StringLength(100)] string RazonSocialEmisor,
    [Range(0.01, double.MaxValue)] decimal Monto
);
