using API_MECANICA_JULIANO.BaseDados.Models;
using API_MECANICA_JULIANO.Services.DTOs;

namespace API_MECANICA_JULIANO.Services.Parsers
{
    // Classe responsável por converter entre entidade Funcionario e seus DTOs
    public static class FuncionarioParser
    {
        // Converte a entidade Funcionario para o DTO de saída (FuncionarioDTO)
        public static FuncionarioDTO ToDTO(this Funcionario entity)
        {
            return new FuncionarioDTO
            {
                IdFuncionario = entity.IdFuncionario,
                Nome = entity.Nome!,        // O ! indica que o valor não deve ser nulo
                Funcao = entity.Funcao!,    // Assume que a função foi preenchida
                Telefone = entity.Telefone  // Pode ser nulo
            };
        }

        // Converte o DTO de criação (CriarFuncionarioDTO) para entidade Funcionario
        public static Funcionario ToEntity(this CriarFuncionarioDTO dto)
        {
            return new Funcionario
            {
                Nome = dto.Nome,
                Funcao = dto.Funcao,
                Telefone = dto.Telefone
            };
        }
    }
}
