using Application.Interface;
using Domain.DTOS.Request;
using Domain.DTOS.Request.UsuarioRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _context;
        public UsuarioController(IUsuario context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult CadastrarUsuario(CadastrarUsuarioRequestDTO dto)
        {
            try
            {
                var resultado = _context.CadastrarUsuario(dto);
                if (resultado.IsFailed) return BadRequest(resultado.Reasons);
                return Ok(resultado.Reasons);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AtivarUsuario")]
        public IActionResult AtivarUsuario(AtivarContaDTO dto)
        {
            try
            {
                var resultado = _context.AtivarUsuario(dto);
                if (resultado.IsFailed) return BadRequest(resultado.Reasons);
                return Ok(resultado.Reasons);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
