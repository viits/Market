using Application.Interface;
using Domain.Data;
using Domain.DTOS.Request;
using Domain.Model;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LoginService : ILogin
    {
        private MarketContext _context;
        private TokenService _tokenService;
        public LoginService(MarketContext marketContext, TokenService tokenService)
        {
            _context = marketContext;
            _tokenService = tokenService;
        }
        public Result LoginMercado(LoginRequestDTO login)
        {
            try
            {
                var mercado = _context.Mercados.Where(m => m.Email == login.Email && m.Senha == login.Senha).FirstOrDefault();
                if (mercado == null) return Result.Fail("Email ou senha Invalidas! ");
                if (mercado.Ativo == 0) return Result.Fail("Mercado não esta ativo! ");
                var logar = new LogaTokenRequestDTO()
                {
                    Nome = mercado.NomeMercado,
                    Id = mercado.Id
                };
                Token token = _tokenService.CreateTokenMercado(logar);
                return Result.Ok().WithSuccess(token.Value);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public Result LoginUsuario(LoginRequestDTO login)
        {
            try
            {
                var usuario = _context.Usuarios.Where(m => m.Email == login.Email && m.Senha == login.Senha).FirstOrDefault();
                if (usuario == null) return Result.Fail("Email ou senha Invalidas! ");
                if (usuario.Ativo == 0) return Result.Fail("Mercado não esta ativo! ");
                var loga = new LogaTokenRequestDTO()
                {
                    Nome = usuario.NomeUsuario,
                    Id = usuario.Id
                };
                Token token = _tokenService.CreateTokenMercado(loga);
                return Result.Ok().WithSuccess(token.Value);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
    }
}
