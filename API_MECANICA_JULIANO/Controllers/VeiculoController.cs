using API_MECANICA_JULIANO.Services;
using API_MECANICA_JULIANO.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API_MECANICA_JULIANO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    public class VeiculoController : ControllerBase
    {
        private readonly VeiculoService _service;

        public VeiculoController(VeiculoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeiculoDTO>>> Get()
        {
            var veiculos = await _service.GetAllAsync();
            return Ok(veiculos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VeiculoDTO>> GetById(int id)
        {
            var veiculo = await _service.GetByIdAsync(id);
            if (veiculo == null)
                return NotFound();

            return Ok(veiculo);
        }

        [HttpPost]
        public async Task<ActionResult<VeiculoDTO>> Post([FromBody] CriarVeiculoDTO dto)
        {
            var novoVeiculo = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = novoVeiculo.IdVeiculo }, novoVeiculo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AtualizarVeiculoDTO dto)
        {
            var atualizado = await _service.UpdateAsync(id, dto);
            if (atualizado == null)
                return NotFound();

            return Ok(atualizado);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _service.DeleteAsync(id);
            if (!removido)
                return NotFound();

            return NoContent();
        }
    }
}
