using MsFacturacion.Api.Domain.Enums;

namespace MsFacturacion.Api.Domain.Entities;

public class Comprobante
{
    public Guid Id { get; set; }
    public TipoComprobante TipoComprobante { get; set; }
    public string Serie { get; set; } = string.Empty;
    public int Numero { get; set; }
    public DateOnly FechaEmision { get; set; }
    public TimeOnly HoraEmision { get; set; }
    public string Moneda { get; set; } = "PEN";
    public string TipoOperacion { get; set; } = string.Empty;
    public TipoPago FormaPago { get; set; }
    public decimal MontoTotal { get; set; }
    public string MontoEnLetras { get; set; } = string.Empty;
    public decimal Subtotal { get; set; }
    public decimal TotalIGV { get; set; }
    public string Hash { get; set; } = string.Empty;
    public string CodigoQR { get; set; } = string.Empty;
    public string Estado { get; set; } = "Pendiente";
    public Guid? ComprobanteRelacionadoId { get; set; }
    public string? MotivoNotaCodigo { get; set; }
    public string? MotivoNotaDescripcion { get; set; }
    public byte[]? FirmaDigital { get; set; }
    public string EnlaceConsultaSunat { get; set; } = string.Empty;

    public ICollection<DetalleComprobante> Detalles { get; set; } = new List<DetalleComprobante>();
    public ICollection<FormaPago> Pagos { get; set; } = new List<FormaPago>();
    public Guid ClienteId { get; set; }
    public Cliente? Cliente { get; set; }
    public Guid EmisorId { get; set; }
    public Emisor? Emisor { get; set; }
}
