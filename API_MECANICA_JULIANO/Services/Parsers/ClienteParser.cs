using API_MECANICA_JULIANO.BaseDados.Models;
using API_MECANICA_JULIANO.Services.DTOs;

namespace API_MECANICA_JULIANO.Services.Parsers
{
    public static class ClienteParser
    {
        public static ClienteDTO ToDTO(this Cliente cliente) => new()
        {
            IdCliente = cliente.IdCliente,
            Nome = cliente.Nome,
            Telefone = cliente.Telefone
        };

        public static Cliente ToEntity(this CriarClienteDTO dto) => new()
        {
            Nome = dto.Nome,
            Telefone = dto.Telefone
        };
    }
}
