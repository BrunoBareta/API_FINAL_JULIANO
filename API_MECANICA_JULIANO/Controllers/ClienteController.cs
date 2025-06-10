using API_MECANICA_JULIANO.Services;
using API_MECANICA_JULIANO.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API_MECANICA_JULIANO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _service;

        public ClienteController(ClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> GetById(int id)
        {
            var cliente = await _service.GetByIdAsync(id);
            return cliente == null ? NotFound() : Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> Post([FromBody] CriarClienteDTO dto)
        {
            var novo = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = novo.IdCliente }, novo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteDTO>> Put(int id, [FromBody] AtualizarClienteDTO dto)
        {
            var atualizado = await _service.UpdateAsync(id, dto);
            return atualizado == null ? NotFound() : Ok(atualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _service.DeleteAsync(id) ? NoContent() : NotFound();
        }
    }
}
