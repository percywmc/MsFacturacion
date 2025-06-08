using System;

namespace MsFacturacion.Api.Domain;

/// <summary>
/// Entidad que representa un comprobante de pago.
/// </summary>
public class Comprobante
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public TipoComprobante Tipo { get; set; }
    public string RucEmisor { get; set; } = string.Empty;
    public string RazonSocialEmisor { get; set; } = string.Empty;
    public decimal Monto { get; set; }
    public DateTime FechaEmision { get; set; } = DateTime.UtcNow;
}
