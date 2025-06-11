using MsFacturacion.Api.Domain.Enums;

namespace MsFacturacion.Api.Domain.Entities;

public class FormaPago
{
    public Guid Id { get; set; }
    public Guid ComprobanteId { get; set; }
    public Comprobante? Comprobante { get; set; }
    public TipoPago TipoPago { get; set; }
    public int Cuotas { get; set; }
    public DateOnly FechaVencimiento { get; set; }
    public decimal MontoCuota { get; set; }
}
