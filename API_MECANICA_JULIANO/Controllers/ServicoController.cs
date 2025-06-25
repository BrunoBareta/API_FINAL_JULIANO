using API_MECANICA_JULIANO.Services;
using API_MECANICA_JULIANO.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API_MECANICA_JULIANO.Controllers
{
    // Define que é um controller de API
    [ApiController]
    // Define a rota base: api/servico
    [Route("api/[controller]")]
    public class ServicoController : ControllerBase
    {
        // Injeta o serviço que lida com a lógica de negócio da entidade Servico
        private readonly ServicoService _service;

        // Construtor que recebe o serviço via injeção de dependência
        public ServicoController(ServicoService service)
        {
            _service = service;
        }

        // GET: retorna todos os serviços cadastrados
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        // GET por ID: retorna um serviço específico
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound(); // Retorna 404 se não encontrar
            return Ok(result); // Retorna 200 com o serviço encontrado
        }

        // PUT: atualiza os dados de um serviço
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AtualizarServicoDTO dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound(); // Retorna 404 se o serviço não existir
            return Ok(updated); // Retorna 200 com os dados atualizados
        }

        // POST: cria um novo serviço
        [HttpPost]
        public async Task<IActionResult> Create(CriarServicoDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            // Retorna 201 (Created) com a localização do novo recurso
            return CreatedAtAction(nameof(GetById), new { id = created.IdServico }, created);
        }

        // DELETE: remove um serviço pelo ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound(); // Se não encontrar, retorna 404
            return NoContent(); // Retorna 204 (sem conteúdo) se for deletado com sucesso
        }
    }
}
