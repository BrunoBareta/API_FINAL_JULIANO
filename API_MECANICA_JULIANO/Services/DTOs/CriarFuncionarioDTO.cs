namespace API_MECANICA_JULIANO.Services.DTOs
{
    public class CriarFuncionarioDTO
    {
        public string Nome { get; set; } = null!;
        public string Funcao { get; set; } = null!;
        public string? Telefone { get; set; }
    }
}
