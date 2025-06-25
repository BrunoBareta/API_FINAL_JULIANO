using AutoMapper;
using API_MECANICA_JULIANO.BaseDados.Models;
using API_MECANICA_JULIANO.Services.DTOs;

namespace API_MECANICA_JULIANO.Mapping
{
    // Classe que define os mapeamentos entre modelos e DTOs
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            // Mapeia de CriarVeiculoDTO para a entidade Veiculo
            CreateMap<CriarVeiculoDTO, Veiculo>();

            // Mapeia de Veiculo para VeiculoDTO (usado para retornar dados)
            CreateMap<Veiculo, VeiculoDTO>();

            // Mapeia de VeiculoDTO para Veiculo (pouco comum, mas útil se precisar atualizar com base no DTO)
            CreateMap<VeiculoDTO, Veiculo>();

            // Mapeia de CriarOrdemServicoDTO para entidade OrdemServico
            CreateMap<CriarOrdemServicoDTO, OrdemServico>();

            // Mapeia de OrdemServico para OrdemServicoDTO (para retorno dos dados)
            CreateMap<OrdemServico, OrdemServicoDTO>();
        }
    }
}
