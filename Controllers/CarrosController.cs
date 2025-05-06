// Controller responsável pelas operações CRUD da entidade Carro.

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CP_02_Locadora.Models;

namespace CP_02_Locadora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // Gerencia os endpoints /api/carros
    public class CarrosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarrosController(AppDbContext context)
        {
            _context = context;
        }

        // Retorna todos os carros cadastrados.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carro>>> Get()
        {
            return await _context.Carros.ToListAsync();
        }

        // Retorna um carro específico pelo ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<Carro>> Get(int id)
        {
            var carro = await _context.Carros.FindAsync(id);
            if (carro == null) return NotFound();
            return carro;
        }

        // Cadastra um novo carro.
        [HttpPost]
        public async Task<ActionResult<Carro>> Post(Carro carro)
        {
            _context.Carros.Add(carro);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = carro.Id }, carro);
        }

        // Atualiza os dados de um carro existente.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Carro carro)
        {
            if (id != carro.Id) return BadRequest();
            _context.Entry(carro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Remove um carro pelo ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var carro = await _context.Carros.FindAsync(id);
            if (carro == null) return NotFound();
            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
