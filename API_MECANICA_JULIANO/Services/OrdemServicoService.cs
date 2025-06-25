using API_MECANICA_JULIANO.BaseDados;
using API_MECANICA_JULIANO.BaseDados.Models;
using API_MECANICA_JULIANO.Services.DTOs;
using API_MECANICA_JULIANO.Services.Parsers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_MECANICA_JULIANO.Services
{
    public class OrdemServicoService
    {
        private readonly TrabalhoMecanicaContext _context;
        private readonly IMapper _mapper;

        public OrdemServicoService(TrabalhoMecanicaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<OrdemServicoDTO>> GetAllAsync()
        {
            var ordens = await _context.OrdemServicos.ToListAsync();
            return ordens.Select(o => o.ToDTO());
        }

        public async Task<OrdemServicoDTO?> GetByIdAsync(int id)
        {
            var ordem = await _context.OrdemServicos.FindAsync(id);
            return ordem?.ToDTO();
        }

        public async Task<OrdemServicoDTO> CreateAsync(CriarOrdemServicoDTO dto)
        {
            //REGRA DE NEGÓCIO
            var ordemAberta = await _context.OrdemServicos
                .FirstOrDefaultAsync(o => o.IdVeiculo == dto.IdVeiculo && o.Status.ToLower() == "aberta");

            if (ordemAberta != null)
                throw new Exception("Já existe uma ordem de serviço aberta para este veículo.");

            //NORMAL
            var entity = _mapper.Map<OrdemServico>(dto);
            _context.OrdemServicos.Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrdemServicoDTO>(entity);
        }


        public async Task<OrdemServicoDTO?> UpdateAsync(int id, AtualizarOrdemServicoDTO dto)

        {
            var entity = await _context.OrdemServicos.FindAsync(id);
            if (entity == null)
                return null;

            entity.DataAbertura = dto.DataAbertura;
            entity.DataFechamento = dto.DataFechamento;
            entity.Status = dto.Status ?? entity.Status; // aqui o ajuste
            entity.IdVeiculo = dto.IdVeiculo;
            entity.IdCliente = dto.IdCliente;
            entity.IdFuncionario = dto.IdFuncionario;

            await _context.SaveChangesAsync();
            return entity.ToDTO();
        }




        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.OrdemServicos.FindAsync(id);
            if (entity == null) return false;

            _context.OrdemServicos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
