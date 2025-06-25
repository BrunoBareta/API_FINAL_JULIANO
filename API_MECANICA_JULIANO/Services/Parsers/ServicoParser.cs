using API_MECANICA_JULIANO.BaseDados.Models;
using API_MECANICA_JULIANO.Services.DTOs;

namespace API_MECANICA_JULIANO.Services.Parsers
{
    // Classe que converte entre a entidade Servico e os DTOs correspondentes
    public static class ServicoParser
    {
        // Converte a entidade Servico para o DTO (usado para retornar os dados ao usuário)
        public static ServicoDTO ToDTO(this Servico servico)
        {
            return new ServicoDTO
            {
                IdServico = servico.IdServico,
                Descricao = servico.Descricao!, // ! assume que não será nulo
                Valor = servico.Valor
            };
        }

        // Converte o DTO de criação para a entidade Servico (usado para salvar no banco)
        public static Servico ToEntity(this CriarServicoDTO dto)
        {
            return new Servico
            {
                Descricao = dto.Descricao,
                Valor = dto.Valor
            };
        }
    }
}
