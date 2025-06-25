namespace API_MECANICA_JULIANO.Services.DTOs
{
    public class AtualizarOrdemServicoDTO
    {
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public string? Status { get; set; }
        public int IdVeiculo { get; set; }
        public int IdCliente { get; set; }
        public int IdFuncionario { get; set; }
    }
}
