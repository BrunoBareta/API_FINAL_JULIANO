using API_MECANICA_JULIANO.Services.DTOs;
using FluentValidation;

namespace API_MECANICA_JULIANO.Services.Validators
{
    public class FuncionarioDTOValidator : AbstractValidator<CriarFuncionarioDTO>
    {
        public FuncionarioDTOValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Funcao).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Telefone).MaximumLength(20);
        }
    }
}
