namespace API_MECANICA_JULIANO.Services.DTOs
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
    }

    public class CriarClienteDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
    }

    public class AtualizarClienteDTO
    {
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
    }
}
        