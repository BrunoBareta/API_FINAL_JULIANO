// Importa os DTOs e o FluentValidation
using API_MECANICA_JULIANO.Services.DTOs;
using FluentValidation;

namespace API_MECANICA_JULIANO.Services.Validators
{
    // Validação para criação de cliente
    public class CriarClienteDTOValidator : AbstractValidator<CriarClienteDTO>
    {
        public CriarClienteDTOValidator()
        {
            // Nome é obrigatório na criação
            RuleFor(c => c.Nome).NotEmpty().WithMessage("Nome é obrigatório");

            // Telefone é obrigatório na criação
            RuleFor(c => c.Telefone).NotEmpty().WithMessage("Telefone é obrigatório");
        }
    }

    // Validação para atualização de cliente
    public class AtualizarClienteDTOValidator : AbstractValidator<AtualizarClienteDTO>
    {
        public AtualizarClienteDTOValidator()
        {
            // Se o Nome for enviado, ele não pode estar vazio
            RuleFor(c => c.Nome).NotEmpty().When(c => c.Nome != null);

            // Se o Telefone for enviado, ele não pode estar vazio
            RuleFor(c => c.Telefone).NotEmpty().When(c => c.Telefone != null);
        }
    }
}
