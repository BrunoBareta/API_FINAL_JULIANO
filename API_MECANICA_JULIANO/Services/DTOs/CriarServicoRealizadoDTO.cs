namespace API_MECANICA_JULIANO.Services.DTOs
{
    public class CriarServicoRealizadoDTO
    {
        public int IdOrdemServico { get; set; }
        public int IdServico { get; set; }
        public int Quantidade { get; set; }
        public decimal Subtotal { get; set; }
        public int IdFuncionario { get; set; }

    }
}
