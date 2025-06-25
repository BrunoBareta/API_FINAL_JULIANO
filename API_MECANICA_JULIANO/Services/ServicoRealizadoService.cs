using API_MECANICA_JULIANO.BaseDados;
using API_MECANICA_JULIANO.BaseDados.Models;
using API_MECANICA_JULIANO.Services.DTOs;
using API_MECANICA_JULIANO.Services.Parsers;
using Microsoft.EntityFrameworkCore;

namespace API_MECANICA_JULIANO.Services
{
    public class ServicoRealizadoService
    {
        private readonly TrabalhoMecanicaContext _context;

        public ServicoRealizadoService(TrabalhoMecanicaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServicoRealizadoDTO>> GetAllAsync()
        {
            var servicos = await _context.ServicoRealizados.ToListAsync();
            return servicos.Select(s => s.ToDTO());
        }

        public async Task<ServicoRealizadoDTO?> GetByIdAsync(int id)
        {
            var servico = await _context.ServicoRealizados.FindAsync(id);
            return servico?.ToDTO();
        }

        public async Task<ServicoRealizadoDTO> CreateAsync(CriarServicoRealizadoDTO dto)
        {
            var entity = dto.ToEntity();
            _context.ServicoRealizados.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ToDTO();
        }

        public async Task<ServicoRealizadoDTO?> UpdateAsync(int id, AtualizarServicoRealizadoDTO dto)
        {
            var entity = await _context.ServicoRealizados.FindAsync(id);
            if (entity == null)
                return null;

            entity.Quantidade = dto.Quantidade;
            entity.Subtotal = dto.Subtotal;

            await _context.SaveChangesAsync();
            return entity.ToDTO();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.ServicoRealizados.FindAsync(id);
            if (entity == null) return false;

            _context.ServicoRealizados.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
