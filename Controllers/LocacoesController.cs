// Controller responsável por calcular o valor total de uma locação de carro.

using Microsoft.AspNetCore.Mvc;
using CP_02_Locadora.Models;

namespace CP_02_Locadora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // Calcula locações através do endpoint /api/locacoes/calcular
    public class LocacoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LocacoesController(AppDbContext context)
        {
            _context = context;
        }

        // Calcula o valor da locação com base nas datas e aplica desconto conforme os dias.
        [HttpPost("calcular")]
        public async Task<ActionResult<LocacaoResponse>> CalcularLocacao([FromBody] LocacaoRequest request)
        {
            var carro = await _context.Carros.FindAsync(request.CarroId);
            if (carro == null)
                return NotFound("Carro não encontrado.");

            int dias = (int)(request.DataFim - request.DataInicio).TotalDays;
            if (dias <= 0)
                return BadRequest("A data final deve ser posterior à data inicial.");

            double subtotal = dias * carro.ValorDiaria;
            double desconto = 0;

            if (dias >= 7)
                desconto = 0.10;
            else if (dias >= 3)
                desconto = 0.05;

            double valorFinal = subtotal - (subtotal * desconto);

            var response = new LocacaoResponse
            {
                Carro = carro.Modelo,
                Marca = carro.Marca,
                DataInicio = request.DataInicio,
                DataFim = request.DataFim,
                ValorDiaria = carro.ValorDiaria,
                Subtotal = subtotal,
                Desconto = $"{desconto * 100}%",
                ValorFinal = valorFinal
            };

            return Ok(response);
        }
    }
}
