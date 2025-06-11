using System.Linq;
using MsFacturacion.Api.Application.Comprobantes.DTOs;
using MsFacturacion.Api.Domain;
using MsFacturacion.Api.Domain.Entities;

namespace MsFacturacion.Api.Application.Comprobantes;

public class ComprobanteService : IComprobanteService
{
    private readonly IComprobanteRepository _repository;

    public ComprobanteService(IComprobanteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Comprobante> CreateAsync(CreateComprobanteDto dto, CancellationToken cancellationToken)
    {
        var comprobante = new Comprobante
        {
            Id = Guid.NewGuid(),
            TipoComprobante = dto.TipoComprobante,
            Serie = dto.Serie,
            Numero = dto.Numero,
            ClienteId = dto.ClienteId,
            EmisorId = dto.EmisorId,
            MontoTotal = dto.MontoTotal,
            FechaEmision = DateOnly.FromDateTime(DateTime.UtcNow),
            HoraEmision = TimeOnly.FromDateTime(DateTime.UtcNow),
            Subtotal = dto.Detalles.Sum(d => d.Cantidad * d.ValorUnitario),
            TotalIGV = dto.Detalles.Sum(d => d.Cantidad * d.ValorUnitario * 0.18m)
        };

        foreach (var detalle in dto.Detalles)
        {
            comprobante.Detalles.Add(new DetalleComprobante
            {
                Id = Guid.NewGuid(),
                Descripcion = detalle.Descripcion,
                Cantidad = detalle.Cantidad,
                ValorUnitario = detalle.ValorUnitario,
                TipoIGV = detalle.TipoIGV,
                MontoIGV = detalle.Cantidad * detalle.ValorUnitario * 0.18m,
                TotalItem = detalle.Cantidad * detalle.ValorUnitario * 1.18m
            });
        }

        comprobante.MontoEnLetras = ""; // TODO: convert to text

        return await _repository.AddAsync(comprobante, cancellationToken);
    }

    public Task<Comprobante?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => _repository.GetByIdAsync(id, cancellationToken);
}
