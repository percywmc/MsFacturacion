using MsFacturacion.Api.Domain.Enums;

namespace MsFacturacion.Api.Domain.Entities;

public class DetalleComprobante
{
    public Guid Id { get; set; }
    public Guid ComprobanteId { get; set; }
    public Comprobante? Comprobante { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public decimal Cantidad { get; set; }
    public string UnidadMedida { get; set; } = string.Empty;
    public decimal ValorUnitario { get; set; }
    public decimal Descuento { get; set; }
    public TipoIGV TipoIGV { get; set; }
    public decimal MontoIGV { get; set; }
    public decimal TotalItem { get; set; }
}
