using API_MECANICA_JULIANO.Services;
using API_MECANICA_JULIANO.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API_MECANICA_JULIANO.Controllers
{
    // Indica que este controller é para API
    [ApiController]
    // Define a rota: api/servicorealizado
    [Route("api/[controller]")]
    public class ServicoRealizadoController : ControllerBase
    {
        // Injeta o serviço que contém a lógica de negócio
        private readonly ServicoRealizadoService _service;

        // Construtor que recebe o serviço por injeção de dependência
        public ServicoRealizadoController(ServicoRealizadoService service)
        {
            _service = service;
        }

        // GET: retorna todos os serviços realizados
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        // GET por ID: retorna um serviço realizado específico
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound(); // 404 se não encontrado
            return Ok(result); // 200 com os dados
        }

        // POST: cria um novo serviço realizado
        [HttpPost]
        public async Task<IActionResult> Create(CriarServicoRealizadoDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            // Retorna 201 com a localização do novo recurso
            return CreatedAtAction(nameof(GetById), new { id = created.IdServicoRealizado }, created);
        }

        // PUT: atualiza um serviço realizado existente
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ServicoRealizadoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] AtualizarServicoRealizadoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // 400 se os dados forem inválidos

            var atualizado = await _service.UpdateAsync(id, dto);
            if (atualizado == null)
                return NotFound(); // 404 se não encontrado

            return Ok(atualizado); // 200 com os dados atualizados
        }

        // DELETE: remove um serviço realizado pelo ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound(); // 404 se não encontrado
            return NoContent(); // 204 se deletado com sucesso
        }
    }
}
