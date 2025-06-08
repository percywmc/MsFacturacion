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

    public void Update(Comprobante comprobante)
    {
        var index = _db.FindIndex(c => c.Id == comprobante.Id);
        if (index >= 0)
        {
            _db[index] = comprobante;
        }
    }

    public Comprobante? GetById(Guid id)
    {
        return _db.FirstOrDefault(c => c.Id == id);
    }

    public IEnumerable<Comprobante> GetAll()
    {
        return _db.ToList();
    }
}
