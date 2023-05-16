using Application.Interface;
using Domain.DTOS.Request;
using Domain.DTOS.Request.MercadoRequet;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MercadoController:ControllerBase
    {
        private readonly IMercado _context;
        public MercadoController(IMercado context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult CadastrarMercado([FromBody] CadastrarMercadoRequestDTO mercadoDTO)
        {
            var resultado = _context.CadastrarMercado(mercadoDTO);
            if (resultado.IsFailed) return BadRequest(resultado.Reasons);
            return Ok(resultado.Reasons);
        }
        [HttpPost("AtivaMercado")]
        public IActionResult AtivarMercado([FromBody] AtivarContaDTO conta)
        {
            var resultado = _context.AtivarMercado(conta);
            if (resultado.IsFailed) return BadRequest(resultado.Reasons);
            return Ok(resultado.Reasons);
        }
    }
}
