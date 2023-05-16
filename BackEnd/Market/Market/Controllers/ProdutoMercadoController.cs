using Application.Interface;
using Domain.DTOS.Request.ProdutoMercadoRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProdutoMercadoController : ControllerBase
    {
        private readonly IProdutoMercado _context;
        private readonly IHttpContextAccessor _httpContext;
        public ProdutoMercadoController(IProdutoMercado context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }
        
        [HttpPost]
        public IActionResult CadastrarProdutoMercado(CadastrarProdutoMercadoRequestDTO dto)
        {
            try
            {
                var resultado = _context.CadastrarProdutoMercado(dto);
                if (resultado.IsFailed) return BadRequest(resultado.Reasons); 
                return Ok(resultado.Reasons);
            }catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
        [HttpGet]
        public IActionResult getProdutosMercados()
        {
            try
            {
                return Ok(_context.TodosProdutosMercados(Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(x => x.Type == "id")?.Value)));

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
