using Application.Interface;
using Domain.DTOS.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ListaController : ControllerBase
    {
        private readonly ILista _lista;
        private readonly IHttpContextAccessor _httpContext;

        public ListaController(ILista lista, IHttpContextAccessor httpContext)
        {
            _lista = lista;
            _httpContext = httpContext;
        }

        [HttpPost]
        public IActionResult CadastrarLista(CadastrarListaRequestDTO dto) 
        {
            try
            {
                dto.UsuarioId = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(x => x.Type == "id")?.Value);
                var resultado = _lista.CadastrarLista(dto);
                if (resultado.IsFailed) return BadRequest(resultado.Reasons);
                return Ok(resultado.Reasons);
            }catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult getLista()
        {
            try
            {
                var resultado = _lista.getList(Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(x => x.Type == "id")?.Value));
                
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("compararPrecos")]
        public IActionResult Comparar([FromQuery] int mercadoId)
        {
            try
            {
                var resultado = _lista.ComparaPrecos(mercadoId);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
