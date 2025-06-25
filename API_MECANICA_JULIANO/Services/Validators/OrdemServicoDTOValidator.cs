using API_MECANICA_JULIANO.Services.DTOs;
using FluentValidation;

namespace API_MECANICA_JULIANO.Services.Validators
{
    public class OrdemServicoDTOValidator : AbstractValidator<CriarOrdemServicoDTO>
    {
        public OrdemServicoDTOValidator()
        {
            RuleFor(x => x.DataAbertura).NotEmpty();
            RuleFor(x => x.Status).NotEmpty().MaximumLength(20);
            RuleFor(x => x.IdVeiculo).GreaterThan(0);
            RuleFor(x => x.IdCliente).GreaterThan(0);
            RuleFor(x => x.IdFuncionario).GreaterThan(0);
        }
    }
}
