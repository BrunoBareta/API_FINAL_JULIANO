using FluentValidation;

public class CriarClienteDTOValidator : AbstractValidator<CriarClienteDTO>
{
    public CriarClienteDTOValidator()
    {
        RuleFor(c => c.Nome).NotEmpty().WithMessage("O nome é obrigatório.");
        RuleFor(c => c.Telefone).NotEmpty().WithMessage("O telefone é obrigatório.");
        RuleFor(c => c.Email).EmailAddress().WithMessage("E-mail inválido.");
        RuleFor(c => c.Endereco).NotEmpty().WithMessage("O endereço é obrigatório.");
    }
}
