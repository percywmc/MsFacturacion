using MsFacturacion.Api.Domain;
using System.Collections.Generic;

namespace MsFacturacion.Api.Application;

/// <summary>
/// Servicio de aplicación para gestionar comprobantes usando CQRS.
/// </summary>
public class ComprobanteService
{
    private readonly IComprobanteRepository _repository;

    public ComprobanteService(IComprobanteRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Comando para emitir un comprobante de pago.
    /// </summary>
    public Comprobante Emitir(Comprobante comprobante)
    {
        _repository.Add(comprobante);
        return comprobante;
    }

    /// <summary>
    /// Comando para anular un comprobante de pago.
    /// </summary>
    public void Anular(Guid id)
    {
        var comprobante = _repository.GetById(id);
        if (comprobante is null)
        {
            return;
        }

        comprobante.Anulado = true;
        _repository.Update(comprobante);
    }

    /// <summary>
    /// Emite una nota de cr\u00e9dito asociada a un comprobante.
    /// </summary>
    public Comprobante EmitirNotaCredito(Guid comprobanteId, decimal monto)
    {
        var comprobanteOrigen = _repository.GetById(comprobanteId);
        if (comprobanteOrigen is null)
        {
            throw new InvalidOperationException("Comprobante no encontrado");
        }

        var nota = new Comprobante
        {
            Tipo = TipoComprobante.NotaCredito,
            RucEmisor = comprobanteOrigen.RucEmisor,
            RazonSocialEmisor = comprobanteOrigen.RazonSocialEmisor,
            Monto = monto,
            RelacionadoId = comprobanteId
        };

        _repository.Add(nota);
        return nota;
    }

    /// <summary>
    /// Consulta para obtener un comprobante por Id.
    /// </summary>
    public Comprobante? ObtenerPorId(Guid id)
    {
        return _repository.GetById(id);
    }

    /// <summary>
    /// Consulta para obtener todos los comprobantes.
    /// </summary>
    public IEnumerable<Comprobante> ObtenerTodos()
    {
        return _repository.GetAll();
    }
}
