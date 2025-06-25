namespace API_MECANICA_JULIANO.Services.DTOs
{
    public class OrdemServicoDTO
    {
        public int IdOrdemServico { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public string Status { get; set; } = string.Empty;

        public int IdVeiculo { get; set; }
        public int IdCliente { get; set; }
        public int IdFuncionario { get; set; }
    }
}
