using API_MECANICA_JULIANO.BaseDados;
using API_MECANICA_JULIANO.BaseDados.Models;
using API_MECANICA_JULIANO.Services.DTOs;
using API_MECANICA_JULIANO.Services.Parsers;
using Microsoft.EntityFrameworkCore;

namespace API_MECANICA_JULIANO.Services
{
    public class ClienteService
    {
        private readonly TrabalhoMecanicaContext _context;

        public ClienteService(TrabalhoMecanicaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClienteDTO>> GetAllAsync()
        {
            return await _context.Clientes
                .Select(c => c.ToDTO())
                .ToListAsync();
        }

        public async Task<ClienteDTO?> GetByIdAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            return cliente?.ToDTO();
        }

        public async Task<ClienteDTO> CreateAsync(CriarClienteDTO dto)
        {
            var entity = dto.ToEntity();
            _context.Clientes.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ToDTO();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ClienteDTO?> UpdateAsync(int id, AtualizarClienteDTO dto)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return null;

            if (dto.Nome != null)
                cliente.Nome = dto.Nome;

            if (dto.Telefone != null)
                cliente.Telefone = dto.Telefone;

            await _context.SaveChangesAsync();
            return cliente.ToDTO();
        }
    }
}
