using MsFacturacion.Api.Domain;

namespace MsFacturacion.Api.Application;

/// <summary>
/// Contrato de persistencia para comprobantes.
/// </summary>
public interface IComprobanteRepository
{
    void Add(Comprobante comprobante);
    void Update(Comprobante comprobante);

    Comprobante? GetById(Guid id);
    IEnumerable<Comprobante> GetAll();
}
