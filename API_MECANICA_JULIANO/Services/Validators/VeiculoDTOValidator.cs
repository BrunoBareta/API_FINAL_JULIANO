using FluentValidation;
using API_MECANICA_JULIANO.Services.DTOs;

namespace API_MECANICA_JULIANO.Services.Validators
{
    public class VeiculoDTOValidator : AbstractValidator<VeiculoDTO>
    {
        public VeiculoDTOValidator()
        {
            RuleFor(v => v.Placa).NotEmpty().Length(7, 10);
            RuleFor(v => v.Modelo).NotEmpty().MaximumLength(50);
            RuleFor(v => v.Ano).InclusiveBetween(1900, DateTime.Now.Year + 1);
            RuleFor(v => v.Cor).MaximumLength(30);
            RuleFor(v => v.IdCliente).GreaterThan(0);
        }
    }
}
