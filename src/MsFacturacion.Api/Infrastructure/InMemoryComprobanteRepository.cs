using System;
using System.Collections.Generic;
using System.Linq;
using MsFacturacion.Api.Application;
using MsFacturacion.Api.Domain;

namespace MsFacturacion.Api.Infrastructure;

/// <summary>
/// Implementación en memoria del repositorio de comprobantes.
/// </summary>
public class InMemoryComprobanteRepository : IComprobanteRepository
{
    private readonly List<Comprobante> _db = new();

    public void Add(Comprobante comprobante)
    {
        _db.Add(comprobante);
    }

    public Comprobante? GetById(Guid id)
    {
        return _db.FirstOrDefault(c => c.Id == id);
    }
}
