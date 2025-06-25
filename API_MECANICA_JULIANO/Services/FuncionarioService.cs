using API_MECANICA_JULIANO.BaseDados;
using API_MECANICA_JULIANO.BaseDados.Models;
using API_MECANICA_JULIANO.Services.DTOs;
using API_MECANICA_JULIANO.Services.Parsers;
using Microsoft.EntityFrameworkCore;

namespace API_MECANICA_JULIANO.Services
{
    public class FuncionarioService
    {
        private readonly TrabalhoMecanicaContext _context;

        public FuncionarioService(TrabalhoMecanicaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FuncionarioDTO>> GetAllAsync()
        {
            var funcionarios = await _context.Funcionarios.ToListAsync();
            return funcionarios.Select(f => f.ToDTO());
        }

        public async Task<FuncionarioDTO?> GetByIdAsync(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            return funcionario?.ToDTO();
        }
        public async Task<FuncionarioDTO?> UpdateAsync(int id, AtualizarFuncionarioDTO dto)
        {
            var entity = await _context.Funcionarios.FindAsync(id);
            if (entity == null)
                return null;

            entity.Nome = dto.Nome;
            entity.Funcao = dto.Funcao;
            entity.Telefone = dto.Telefone;

            await _context.SaveChangesAsync();

            return entity.ToDTO();
        }



        public async Task<FuncionarioDTO> CreateAsync(CriarFuncionarioDTO dto)
        {
            var entity = dto.ToEntity();
            _context.Funcionarios.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ToDTO();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Funcionarios.FindAsync(id);
            if (entity == null) return false;

            _context.Funcionarios.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
