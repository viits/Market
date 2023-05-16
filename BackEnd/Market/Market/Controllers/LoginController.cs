using Application.Interface;
using Domain.DTOS.Request;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _context;
        public LoginController(ILogin login)
        {
            _context = login;
        }
        [HttpPost("LoginMercado")]
        public IActionResult LoginMercado([FromBody]LoginRequestDTO loginRequestDTO)
        {
            try
            {
                var resultado = _context.LoginMercado(loginRequestDTO);
                if (resultado.IsFailed) return BadRequest(resultado.Reasons);
                return Ok(resultado.Reasons);
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("LoginUsuario")]
        public IActionResult LoginUsuario([FromBody]LoginRequestDTO loginRequestDTO)
        {
            try
            {
                var resultado = _context.LoginUsuario(loginRequestDTO);
                if (resultado.IsFailed) return BadRequest(resultado.Reasons);
                return Ok(resultado.Reasons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
