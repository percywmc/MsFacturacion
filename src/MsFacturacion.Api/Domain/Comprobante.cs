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
    /// <summary>
    /// Indica si el comprobante fue anulado.
    /// </summary>
    public bool Anulado { get; set; }

    /// <summary>
    /// Id del comprobante relacionado en caso de notas de crédito o débito.
    /// </summary>
    public Guid? RelacionadoId { get; set; }
}
