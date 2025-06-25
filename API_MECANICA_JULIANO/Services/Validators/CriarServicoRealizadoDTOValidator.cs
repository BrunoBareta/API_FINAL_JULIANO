using FluentValidation;
using API_MECANICA_JULIANO.Services.DTOs;

namespace API_MECANICA_JULIANO.Services.Validators
{
    public class CriarServicoRealizadoDTOValidator : AbstractValidator<CriarServicoRealizadoDTO>
    {
        public CriarServicoRealizadoDTOValidator()
        {
            RuleFor(x => x.IdFuncionario)
                .GreaterThan(0)
                .WithMessage("Todo serviço realizado deve ter um funcionário responsável.");
        }
    }
}
