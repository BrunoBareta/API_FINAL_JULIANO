namespace API_MECANICA_JULIANO.Services.DTOs
{
    public class ServicoDTO
    {
        public int IdServico { get; set; }
        public string Descricao { get; set; } = null!;
        public decimal Valor { get; set; }
    }
}
