using API_MECANICA_JULIANO.BaseDados;
using API_MECANICA_JULIANO.BaseDados.Models;
using API_MECANICA_JULIANO.Services.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_MECANICA_JULIANO.Services
{
    public class VeiculoService
    {
        private readonly TrabalhoMecanicaContext _context;
        private readonly IMapper _mapper;

        public VeiculoService(TrabalhoMecanicaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VeiculoDTO>> GetAllAsync()
        {
            var veiculos = await _context.Veiculos.ToListAsync();
            return _mapper.Map<IEnumerable<VeiculoDTO>>(veiculos);
        }

        public async Task<VeiculoDTO?> GetByIdAsync(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            return veiculo == null ? null : _mapper.Map<VeiculoDTO>(veiculo);
        }

        public async Task<VeiculoDTO> CreateAsync(CriarVeiculoDTO dto)
        {
            var entity = _mapper.Map<Veiculo>(dto);
            _context.Veiculos.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<VeiculoDTO>(entity);
        }

        public async Task<bool> UpdateAsync(int id, VeiculoDTO dto)
        {
            var entity = await _context.Veiculos.FindAsync(id);
            if (entity == null)
                return false;

            _mapper.Map(dto, entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Veiculos.FindAsync(id);
            if (entity == null)
                return false;

            _context.Veiculos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
