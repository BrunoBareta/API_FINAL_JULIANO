// Importa o FluentValidation para validar os campos do DTO
using FluentValidation;
using API_MECANICA_JULIANO.Services.DTOs;

namespace API_MECANICA_JULIANO.Services.Validators
{
    // Validador para atualização de funcionário
    public class AtualizarFuncionarioDTOValidator : AbstractValidator<AtualizarFuncionarioDTO>
    {
        public AtualizarFuncionarioDTOValidator()
        {
            // Nome é obrigatório
            RuleFor(f => f.Nome).NotEmpty().WithMessage("O nome é obrigatório.");

            // Função é obrigatória
            RuleFor(f => f.Funcao).NotEmpty().WithMessage("A função é obrigatória.");

            // Telefone é obrigatório
            RuleFor(f => f.Telefone).NotEmpty().WithMessage("O telefone é obrigatório.");
        }
    }
}
