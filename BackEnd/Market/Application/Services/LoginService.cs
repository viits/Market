using Application.Interface;
using Domain.Data;
using Domain.DTOS.Request;
using Domain.DTOS.Response;
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
        public LoginResponseDTO LoginMercado(LoginRequestDTO login)
        {
            try
            {
                var mercado = _context.Mercados.Where(m => m.Email == login.Email && m.Senha == login.Senha).FirstOrDefault();
                if (mercado == null) return null;
                if (mercado.Ativo == 0) return null;
                var logar = new LogaTokenRequestDTO()
                {
                    Nome = mercado.NomeMercado,
                    Id = mercado.Id
                };
                Token token = _tokenService.CreateTokenMercado(logar);
                LoginResponseDTO loginDTO = new LoginResponseDTO()
                {
                    MercadoId = mercado.Id,
                    Token = token.Value
                };
                return loginDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public LoginUsuarioResponseDTO LoginUsuario(LoginRequestDTO login)
        {
            try
            {
                var usuario = _context.Usuarios.Where(m => m.Email == login.Email && m.Senha == login.Senha).FirstOrDefault();
                if (usuario == null) return null;
                if (usuario.Ativo == 0) return null;
                var loga = new LogaTokenRequestDTO()
                {
                    Nome = usuario.NomeUsuario,
                    Id = usuario.Id
                };
                Token token = _tokenService.CreateTokenMercado(loga);

                LoginUsuarioResponseDTO loginDTO = new LoginUsuarioResponseDTO()
                {
                    UsuarioId = usuario.Id,
                    Token = token.Value
                };
                return loginDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
