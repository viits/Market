using Application.Interface;
using AutoMapper;
using Domain.Data;
using Domain.DTOS.Request;
using Domain.DTOS.Request.UsuarioRequest;
using Domain.Model;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsuarioService : IUsuario
    {
        private readonly MarketContext _context;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;
        private readonly EmailService _emailService;
        public UsuarioService(MarketContext context, IMapper mapper, TokenService tokenService, EmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            _tokenService = tokenService;
            _emailService = emailService;
        }
        public Result CadastrarUsuario(CadastrarUsuarioRequestDTO usuarioDTO)
        {
            try
            {
                if (!verificaEmail(usuarioDTO.Email)) return Result.Fail("Email já existente!");
                var usuario = _mapper.Map<Usuario>(usuarioDTO);
                usuario.Ativo = 0;
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                var mensagemEmail = new EmailRequestDTO()
                {
                    Id = usuario.Id,
                    Email = usuario.Email,
                    Nome = usuario.NomeUsuario
                };
                var token = _tokenService.GeraToken(mensagemEmail.Id);
                _emailService.enviarEmail(mensagemEmail, "Link de Ativação", token.Value);
                return Result.Ok().WithSuccess("Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }

        }
        private bool verificaEmail(string email)
        {
            try
            {
                var mercado = _context.Usuarios.Where(m => m.Email == email).FirstOrDefault();
                if (mercado != null) return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Result AtivarUsuario(AtivarContaDTO request)
        {
            try
            {
                if (_tokenService.verificaToken(request))
                {
                    var usuario = _context.Usuarios.Where(m => m.Id == request.Id).FirstOrDefault();
                    if (usuario == null) return Result.Fail("Usuario não encontrado!");
                    usuario.Ativo = 1;
                    _context.Usuarios.Update(usuario);
                    _context.SaveChanges();
                    return Result.Ok().WithSuccess("Usuario ativado com sucesso!");
                }
                return Result.Fail("Token inválido!");
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
    }
}
