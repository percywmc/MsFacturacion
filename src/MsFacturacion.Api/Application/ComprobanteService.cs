using MsFacturacion.Api.Domain;

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
    /// Consulta para obtener un comprobante por Id.
    /// </summary>
    public Comprobante? ObtenerPorId(Guid id)
    {
        return _repository.GetById(id);
    }
}
