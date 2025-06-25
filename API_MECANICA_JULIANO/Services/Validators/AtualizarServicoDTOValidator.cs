using API_MECANICA_JULIANO.Services.DTOs;
using FluentValidation;

namespace API_MECANICA_JULIANO.Services.Validators
{
    public class AtualizarServicoDTOValidator : AbstractValidator<AtualizarServicoDTO>
    {
        public AtualizarServicoDTOValidator()
        {
            RuleFor(x => x.Descricao).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Valor).GreaterThan(0);
        }
    }
}
