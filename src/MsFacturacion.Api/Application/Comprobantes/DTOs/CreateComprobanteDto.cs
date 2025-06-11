using MsFacturacion.Api.Domain.Enums;

namespace MsFacturacion.Api.Application.Comprobantes.DTOs;

public class CreateComprobanteDto
{
    public TipoComprobante TipoComprobante { get; set; }
    public string Serie { get; set; } = string.Empty;
    public int Numero { get; set; }
    public Guid ClienteId { get; set; }
    public Guid EmisorId { get; set; }
    public decimal MontoTotal { get; set; }
    public ICollection<DetalleDto> Detalles { get; set; } = new List<DetalleDto>();
}

public class DetalleDto
{
    public string Descripcion { get; set; } = string.Empty;
    public decimal Cantidad { get; set; }
    public decimal ValorUnitario { get; set; }
    public TipoIGV TipoIGV { get; set; }
}
