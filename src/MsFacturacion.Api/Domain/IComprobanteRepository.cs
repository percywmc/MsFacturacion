using MsFacturacion.Api.Domain.Entities;

namespace MsFacturacion.Api.Domain;

public interface IComprobanteRepository
{
    Task<Comprobante> AddAsync(Comprobante comprobante, CancellationToken cancellationToken);
    Task<Comprobante?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
