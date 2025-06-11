using Microsoft.EntityFrameworkCore;
using MsFacturacion.Api.Domain;
using MsFacturacion.Api.Domain.Entities;
using MsFacturacion.Api.Infrastructure.Data;

namespace MsFacturacion.Api.Infrastructure.Repositories;

public class ComprobanteRepository : IComprobanteRepository
{
    private readonly MsFacturacionDbContext _context;

    public ComprobanteRepository(MsFacturacionDbContext context)
    {
        _context = context;
    }

    public async Task<Comprobante> AddAsync(Comprobante comprobante, CancellationToken cancellationToken)
    {
        _context.Comprobantes.Add(comprobante);
        await _context.SaveChangesAsync(cancellationToken);
        return comprobante;
    }

    public Task<Comprobante?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _context.Comprobantes
            .Include(c => c.Detalles)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
}
