using API_MECANICA_JULIANO.Services;
using API_MECANICA_JULIANO.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API_MECANICA_JULIANO.Controllers
{
    // Indica que é um controller de API
    [ApiController]
    // Define a rota: api/veiculo
    [Route("api/[controller]")]
    // Define os tipos de resposta permitidos: JSON e XML
    [Produces("application/json", "application/xml")]
    public class VeiculoController : ControllerBase
    {
        // Injeta o serviço responsável pela lógica de veículos
        private readonly VeiculoService _service;

        // Construtor recebe o serviço via injeção de dependência
        public VeiculoController(VeiculoService service)
        {
            _service = service;
        }

        // GET: Retorna todos os veículos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeiculoDTO>>> Get()
        {
            var veiculos = await _service.GetAllAsync();
            return Ok(veiculos); // Retorna 200 com a lista
        }

        // GET por ID: Retorna um veículo específico
        [HttpGet("{id}")]
        public async Task<ActionResult<VeiculoDTO>> GetById(int id)
        {
            var veiculo = await _service.GetByIdAsync(id);
            if (veiculo == null)
                return NotFound(); // Retorna 404 se não encontrar

            return Ok(veiculo); // Retorna 200 com o veículo
        }

        // POST: Cria um novo veículo
        [HttpPost]
        public async Task<ActionResult<VeiculoDTO>> Post([FromBody] CriarVeiculoDTO dto)
        {
            var novoVeiculo = await _service.CreateAsync(dto);
            // Retorna 201 com a URL do novo veículo
            return CreatedAtAction(nameof(GetById), new { id = novoVeiculo.IdVeiculo }, novoVeiculo);
        }

        // PUT: Atualiza os dados de um veículo existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AtualizarVeiculoDTO dto)
        {
            var atualizado = await _service.UpdateAsync(id, dto);
            if (atualizado == null)
                return NotFound(); // 404 se não encontrou

            return Ok(atualizado); // 200 com o dado atualizado
        }

        // DELETE: Remove um veículo pelo ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _service.DeleteAsync(id);
            if (!removido)
                return NotFound(); // 404 se não encontrou

            return NoContent(); // 204 se excluído com sucesso
        }
    }
}
