using API_MECANICA_JULIANO.BaseDados.Models;
using API_MECANICA_JULIANO.Services.DTOs;

namespace API_MECANICA_JULIANO.Services.Parsers
{
    // Classe estática para conversões entre entidade Cliente e DTOs
    public static class ClienteParser
    {
        // Converte um objeto Cliente (entidade) para ClienteDTO (retorno ao usuário)
        public static ClienteDTO ToDTO(this Cliente cliente) => new()
        {
            IdCliente = cliente.IdCliente,
            Nome = cliente.Nome!,             // Assume que o nome não é nulo
            Telefone = cliente.Telefone!      // Assume que o telefone não é nulo
        };

        // Converte um DTO de criação para uma entidade Cliente (para salvar no banco)
        public static Cliente ToEntity(this CriarClienteDTO dto) => new()
        {
            Nome = dto.Nome,
            Telefone = dto.Telefone,
            Email = dto.Email,
            Endereco = dto.Endereco
        };
    }
}
