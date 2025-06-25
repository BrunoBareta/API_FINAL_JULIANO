namespace API_MECANICA_JULIANO.Services.DTOs
{
    public class FuncionarioDTO
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; } = null!;
        public string Funcao { get; set; } = null!;
        public string? Telefone { get; set; }
    }
}
