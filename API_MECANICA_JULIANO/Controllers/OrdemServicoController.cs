using API_MECANICA_JULIANO.Services;
using API_MECANICA_JULIANO.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API_MECANICA_JULIANO.Controllers
{
    // Define que é um controller de API
    [ApiController]
    // Define a rota base: api/ordemservico
    [Route("api/[controller]")]
    public class OrdemServicoController : ControllerBase
    {
        // Injeta o serviço responsável pelas regras da ordem de serviço
        private readonly OrdemServicoService _service;

        public OrdemServicoController(OrdemServicoService service)
        {
            _service = service;
        }

        // GET: retorna todas as ordens de serviço cadastradas
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        // GET por ID: busca uma ordem de serviço específica
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound(); // Se não encontrar, retorna 404
            return Ok(result); // Se encontrar, retorna 200 com os dados
        }

        // POST: cria uma nova ordem de serviço
        [HttpPost]
        public async Task<IActionResult> Create(CriarOrdemServicoDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            // Retorna 201 com a localização do novo recurso
            return CreatedAtAction(nameof(GetById), new { id = created.IdOrdemServico }, created);
        }

        // PUT: atualiza uma ordem de serviço existente
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(OrdemServicoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] AtualizarOrdemServicoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Valida se o modelo enviado está correto

            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null)
                return NotFound(); // Se não existir, retorna 404

            return Ok(updated); // Se atualizar, retorna 200 com os dados atualizados
        }

        // DELETE: remove uma ordem de serviço pelo ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound(); // Se não existir, retorna 404
            return NoContent(); // Se apagar, retorna 204 (sem conteúdo)
        }
    }
}
