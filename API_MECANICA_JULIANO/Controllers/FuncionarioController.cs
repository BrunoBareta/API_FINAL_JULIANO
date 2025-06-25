using API_MECANICA_JULIANO.Services;
using API_MECANICA_JULIANO.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API_MECANICA_JULIANO.Controllers
{
    // Indica que essa classe é um Controller de API
    [ApiController]

    // Define a rota base: api/funcionario
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        // Injeta o serviço de funcionário que lida com a lógica
        private readonly FuncionarioService _service;

        public FuncionarioController(FuncionarioService service)
        {
            _service = service;
        }

        // GET: Retorna todos os funcionários
        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        // GET por ID: Retorna um funcionário específico
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound(); // Se não encontrar, retorna 404
            return Ok(result); // Caso encontre, retorna 200 com o funcionário
        }

        // POST: Cria um novo funcionário
        [HttpPost]
        public async Task<IActionResult> Create(CriarFuncionarioDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            // Retorna 201 com o local do novo recurso
            return CreatedAtAction(nameof(GetById), new { id = created.IdFuncionario }, created);
        }

        // PUT: Atualiza um funcionário existente
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(FuncionarioDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] AtualizarFuncionarioDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Valida os dados recebidos

            var funcionarioAtualizado = await _service.UpdateAsync(id, dto);
            if (funcionarioAtualizado == null)
                return NotFound(); // Caso não encontre o funcionário, retorna 404

            return Ok(funcionarioAtualizado); // Retorna 200 com o funcionário atualizado
        }

        // DELETE: Remove um funcionário pelo ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound(); // Se não encontrar, retorna 404
            return NoContent(); // Retorna 204 se remover com sucesso
        }
    }
}
