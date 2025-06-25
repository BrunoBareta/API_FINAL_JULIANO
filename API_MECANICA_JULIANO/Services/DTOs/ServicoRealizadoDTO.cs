namespace API_MECANICA_JULIANO.Services.DTOs
{
    public class ServicoRealizadoDTO
    {
        public int IdServicoRealizado { get; set; }
        public int IdOrdemServico { get; set; }
        public int IdServico { get; set; }
        public int Quantidade { get; set; }
        public decimal Subtotal { get; set; }
    }
}
