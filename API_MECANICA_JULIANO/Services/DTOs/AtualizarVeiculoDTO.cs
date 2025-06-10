namespace API_MECANICA_JULIANO.Services.DTOs
{
    public class AtualizarVeiculoDTO
    {
        public string Placa { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string? Cor { get; set; }
        public int IdCliente { get; set; }
    }
}
