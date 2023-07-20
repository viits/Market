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
        private readonly IProdutoMercado _produtoMercado;
        public MercadoController(IMercado context, IProdutoMercado mercadoMercado)
        {
            _context = context;
            _produtoMercado = mercadoMercado;

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
        [HttpGet("{id}")]
        public IActionResult GetMercadoById(int id)
        {
            return Ok(_context.getMercadoById(id));
        }
        [HttpGet]
        public IActionResult getMercados()
        {
            return Ok(_context.getListMercado());
        }
        [HttpGet("produtoMercado/{id}")]
        public IActionResult getProdutoMercado(int id)
        {
            var produtoMercado = _produtoMercado.TodosProdutosMercados(id);
            return Ok(produtoMercado);
        }
    }
}
