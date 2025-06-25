using API_MECANICA_JULIANO.Services.DTOs;
using FluentValidation;

namespace API_MECANICA_JULIANO.Services.Validators
{
    public class AtualizarServicoRealizadoDTOValidator : AbstractValidator<AtualizarServicoRealizadoDTO>
    {
        public AtualizarServicoRealizadoDTOValidator()
        {
            RuleFor(x => x.Quantidade).GreaterThan(0);
            RuleFor(x => x.Subtotal).GreaterThanOrEqualTo(0);
        }
    }
}
