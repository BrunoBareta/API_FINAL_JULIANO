using API_MECANICA_JULIANO.BaseDados.Models;
using API_MECANICA_JULIANO.Services.DTOs;

namespace API_MECANICA_JULIANO.Services.Parsers
{
    public static class VeiculoParser
    {
        // Converte entidade para DTO
        public static VeiculoDTO ToDTO(this Veiculo veiculo)
        {
            return new VeiculoDTO
            {
                IdVeiculo = veiculo.IdVeiculo,
                Placa = veiculo.Placa!,
                Modelo = veiculo.Modelo!,
                Ano = veiculo.Ano ?? 0,
                Cor = veiculo.Cor!,
                IdCliente = veiculo.IdCliente
            };
        }

        // Converte DTO de criação para entidade
        public static Veiculo ToEntity(this CriarVeiculoDTO dto)
        {
            return new Veiculo
            {
                Placa = dto.Placa,
                Modelo = dto.Modelo,
                Ano = dto.Ano,
                Cor = dto.Cor,
                IdCliente = dto.IdCliente
            };
        }

        // Converte DTO de atualização para entidade
        public static void AtualizarDados(this Veiculo veiculo, AtualizarVeiculoDTO dto)
        {
            veiculo.Placa = dto.Placa;
            veiculo.Modelo = dto.Modelo;
            veiculo.Ano = dto.Ano;
            veiculo.Cor = dto.Cor;
        }
    }
}
                                            