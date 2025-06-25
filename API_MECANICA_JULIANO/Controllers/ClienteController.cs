using API_MECANICA_JULIANO.Services;
using API_MECANICA_JULIANO.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API_MECANICA_JULIANO.Controllers
{
    // Define que essa classe é uma API Controller
    [ApiController]

    // Rota base: api/cliente
    [Route("api/[controller]")]

    // Define que pode retornar JSON ou XML
    [Produces("application/json", "application/xml")]
    public class ClienteController : ControllerBase
    {
        // Injeção do serviço que contém a lógica de negócios
        private readonly ClienteService _service;

        public ClienteController(ClienteService service)
        {
            _service = service;
        }

        // GET: Retorna todos os clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get() =>
            Ok(await _service.GetAllAsync());

        // GET por ID: Retorna um cliente específico
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> GetById(int id)
        {
            var cliente = await _service.GetByIdAsync(id);
            return cliente == null ? NotFound() : Ok(cliente);
        }

        // POST: Cria um novo cliente
        [HttpPost]
        [ProducesResponseType(typeof(ClienteDTO), StatusCodes.Status201Created)]
        public async Task<ActionResult<ClienteDTO>> Create([FromBody] CriarClienteDTO dto)
        {
            var clienteCriado = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = clienteCriado.IdCliente }, clienteCriado);
        }

        // PUT: Atualiza os dados de um cliente
        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteDTO>> Put(int id, [FromBody] AtualizarClienteDTO dto)
        {
            var atualizado = await _service.UpdateAsync(id, dto);
            return atualizado == null ? NotFound() : Ok(atualizado);
        }

        // DELETE: Remove um cliente
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _service.DeleteAsync(id) ? NoContent() : NotFound();
        }
    }
}
