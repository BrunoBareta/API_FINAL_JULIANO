using API_MECANICA_JULIANO.Services.DTOs;
using FluentValidation;

namespace API_MECANICA_JULIANO.Services.Validators
{
    public class ServicoRealizadoDTOValidator : AbstractValidator<CriarServicoRealizadoDTO>
    {
        public ServicoRealizadoDTOValidator()
        {
            RuleFor(x => x.IdOrdemServico).GreaterThan(0);
            RuleFor(x => x.IdServico).GreaterThan(0);
            RuleFor(x => x.Quantidade).GreaterThan(0);
            RuleFor(x => x.Subtotal).GreaterThanOrEqualTo(0);
        }
    }
}
