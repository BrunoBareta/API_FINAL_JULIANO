using API_MECANICA_JULIANO.BaseDados.Models;
using API_MECANICA_JULIANO.Services.DTOs;

namespace API_MECANICA_JULIANO.Services.Parsers
{
    // Classe utilitária que faz a conversão entre a entidade ServicoRealizado e seus DTOs
    public static class ServicoRealizadoParser
    {
        // Converte a entidade para DTO, usado para exibir dados ao usuário
        public static ServicoRealizadoDTO ToDTO(this ServicoRealizado entity)
        {
            return new ServicoRealizadoDTO
            {
                IdServicoRealizado = entity.IdServicoRealizado,
                IdOrdemServico = entity.IdOrdemServico,
                IdServico = entity.IdServico,
                Quantidade = entity.Quantidade,
                Subtotal = entity.Subtotal
            };
        }

        // Converte o DTO de criação em uma entidade pronta para ser salva no banco
        public static ServicoRealizado ToEntity(this CriarServicoRealizadoDTO dto)
        {
            return new ServicoRealizado
            {
                IdOrdemServico = dto.IdOrdemServico,
                IdServico = dto.IdServico,
                Quantidade = dto.Quantidade,
                Subtotal = dto.Subtotal
            };
        }
    }
}
