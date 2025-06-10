using API_MECANICA_JULIANO.Services.DTOs;
using FluentValidation;

namespace API_MECANICA_JULIANO.Services.Validators
{
    public class CriarClienteDTOValidator : AbstractValidator<CriarClienteDTO>
    {
        public CriarClienteDTOValidator()
        {
            RuleFor(c => c.Nome).NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(c => c.Telefone).NotEmpty().WithMessage("Telefone é obrigatório");
        }
    }

    public class AtualizarClienteDTOValidator : AbstractValidator<AtualizarClienteDTO>
    {
        public AtualizarClienteDTOValidator()
        {
            RuleFor(c => c.Nome).NotEmpty().When(c => c.Nome != null);
            RuleFor(c => c.Telefone).NotEmpty().When(c => c.Telefone != null);
        }
    }
}
