using API_MECANICA_JULIANO.BaseDados.Models;
using API_MECANICA_JULIANO.Services.DTOs;

namespace API_MECANICA_JULIANO.Services.Parsers
{
    public static class OrdemServicoParser
    {
        public static OrdemServicoDTO ToDTO(this OrdemServico entity)
        {
            return new OrdemServicoDTO
            {
                IdOrdemServico = entity.IdOrdemServico,
                DataAbertura = entity.DataAbertura,
                DataFechamento = entity.DataFechamento,
                Status = entity.Status,
                IdVeiculo = entity.IdVeiculo,
                IdCliente = entity.IdCliente,
                IdFuncionario = entity.IdFuncionario
            };
        }

        public static OrdemServico ToEntity(this CriarOrdemServicoDTO dto)
        {
            return new OrdemServico
            {
                DataAbertura = dto.DataAbertura,
                DataFechamento = dto.DataFechamento,
                Status = dto.Status,
                IdVeiculo = dto.IdVeiculo,
                IdCliente = dto.IdCliente,
                IdFuncionario = dto.IdFuncionario
            };
        }
    }
}
