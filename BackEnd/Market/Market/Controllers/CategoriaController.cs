using Application.Interface;
using Domain.DTOS.Request.CategoriaRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoria _context;
        public CategoriaController(ICategoria context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public IActionResult GetCategoria(int id) {
            var dto = _context.GetCategoria(id);
            if(dto == null) return NotFound();
            return Ok(dto);
        }
        [HttpGet]
        public IActionResult GetListCategorias() {
            return Ok(_context.GetListCategorias());
        }
        [HttpPost]
        public IActionResult CadastrarCategoria(CadastrarCategoriaRequestDTO dto)
        {
            var resultado = _context.CadastrarCategoria(dto);
            if (resultado.IsFailed) return BadRequest(resultado.Reasons);
            return Ok(resultado.Reasons);
        }
    }
}
