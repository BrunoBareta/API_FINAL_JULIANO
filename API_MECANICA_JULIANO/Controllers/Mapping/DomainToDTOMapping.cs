using AutoMapper;
using API_MECANICA_JULIANO.BaseDados.Models;
using API_MECANICA_JULIANO.Services.DTOs;

namespace API_MECANICA_JULIANO.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<CriarVeiculoDTO, Veiculo>();
            CreateMap<Veiculo, VeiculoDTO>();
            CreateMap<VeiculoDTO, Veiculo>();
        }
    }
}
