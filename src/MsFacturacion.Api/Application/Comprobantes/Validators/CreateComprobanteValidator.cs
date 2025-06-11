using FluentValidation;
using MsFacturacion.Api.Application.Comprobantes.DTOs;

namespace MsFacturacion.Api.Application.Comprobantes.Validators;

public class CreateComprobanteValidator : AbstractValidator<CreateComprobanteDto>
{
    public CreateComprobanteValidator()
    {
        RuleFor(x => x.Serie).NotEmpty();
        RuleFor(x => x.Numero).GreaterThan(0);
        RuleFor(x => x.ClienteId).NotEmpty();
        RuleFor(x => x.EmisorId).NotEmpty();
        RuleForEach(x => x.Detalles).SetValidator(new DetalleDtoValidator());
    }
}

public class DetalleDtoValidator : AbstractValidator<DetalleDto>
{
    public DetalleDtoValidator()
    {
        RuleFor(x => x.Descripcion).NotEmpty();
        RuleFor(x => x.Cantidad).GreaterThan(0);
        RuleFor(x => x.ValorUnitario).GreaterThan(0);
    }
}
