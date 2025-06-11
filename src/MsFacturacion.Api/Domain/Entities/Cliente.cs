namespace MsFacturacion.Api.Domain.Entities;

public class Cliente
{
    public Guid Id { get; set; }
    public string TipoDocumento { get; set; } = string.Empty;
    public string NumeroDocumento { get; set; } = string.Empty;
    public string NombreCompletoORazonSocial { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;

    public ICollection<Comprobante> Comprobantes { get; set; } = new List<Comprobante>();
}
