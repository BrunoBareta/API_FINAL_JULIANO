using API_MECANICA_JULIANO.BaseDados;
using API_MECANICA_JULIANO.BaseDados.Models;
using API_MECANICA_JULIANO.Services.DTOs;
using API_MECANICA_JULIANO.Services.Parsers;
using Microsoft.EntityFrameworkCore;

namespace API_MECANICA_JULIANO.Services
{
    public class ServicoService
    {
        private readonly TrabalhoMecanicaContext _context;

        public ServicoService(TrabalhoMecanicaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServicoDTO>> GetAllAsync()
        {
            var servicos = await _context.Servicos.ToListAsync();
            return servicos.Select(s => s.ToDTO());
        }

        public async Task<ServicoDTO?> GetByIdAsync(int id)
        {
            var servico = await _context.Servicos.FindAsync(id);
            return servico?.ToDTO();
        }

        public async Task<ServicoDTO?> UpdateAsync(int id, AtualizarServicoDTO dto)
        {
            var servico = await _context.Servicos.FindAsync(id);
            if (servico == null)
                return null;

            servico.Descricao = dto.Descricao;
            servico.Valor = dto.Valor;

            await _context.SaveChangesAsync();
            return servico.ToDTO();
        }


        public async Task<ServicoDTO> CreateAsync(CriarServicoDTO dto)
        {
            var entity = dto.ToEntity();
            _context.Servicos.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ToDTO();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Servicos.FindAsync(id);
            if (entity == null) return false;

            _context.Servicos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;


        }
    }
}
