namespace MsFacturacion.Api.Domain.Entities;

public class Emisor
{
    public Guid Id { get; set; }
    public string RUC { get; set; } = string.Empty;
    public string RazonSocial { get; set; } = string.Empty;
    public string NombreComercial { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public byte[] CertificadoDigital { get; set; } = Array.Empty<byte>();
    public string ClaveCertificado { get; set; } = string.Empty;

    public ICollection<Comprobante> Comprobantes { get; set; } = new List<Comprobante>();
}
