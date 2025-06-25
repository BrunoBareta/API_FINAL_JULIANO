namespace API_MECANICA_JULIANO.Services.DTOs
{
    public class CriarOrdemServicoDTO
    {
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public string Status { get; set; } = null!;
        public int IdVeiculo { get; set; }
        public int IdCliente { get; set; }
        public int IdFuncionario { get; set; }
    }
}
