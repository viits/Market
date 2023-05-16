using Application.Interface;
using Domain.DTOS.Request.ProdutoRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProduto _context;
        public ProdutoController(IProduto context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult cadastrarProduto(CadastrarProdutoRequestDTO produtoDTO)
        {
            var resultado = _context.CadastrarProduto(produtoDTO);
            return Ok(resultado.Successes);
        }
        [HttpGet("{id}")]
        public IActionResult getProdutoById(int id)
        {
            var produtoDTO = _context.GetProdutoId(id);
            if (produtoDTO == null) return NotFound();
            return Ok(produtoDTO);
        }
        [HttpGet]
        public IActionResult getListProduto()
        {
            return Ok(_context.GetProdutoList());
        }
    }
}
