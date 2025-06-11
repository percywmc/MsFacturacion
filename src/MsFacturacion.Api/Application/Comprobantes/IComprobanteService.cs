using MsFacturacion.Api.Application.Comprobantes.DTOs;
using MsFacturacion.Api.Domain.Entities;

namespace MsFacturacion.Api.Application.Comprobantes;

public interface IComprobanteService
{
    Task<Comprobante> CreateAsync(CreateComprobanteDto dto, CancellationToken cancellationToken);
    Task<Comprobante?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
