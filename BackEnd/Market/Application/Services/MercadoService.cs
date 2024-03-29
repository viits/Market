﻿using Application.Interface;
using AutoMapper;
using Domain.Data;
using Domain.DTOS.Request;
using Domain.DTOS.Request.MercadoRequet;
using Domain.DTOS.Response.MercadoResponse;
using Domain.Model;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MercadoService : IMercado
    {
        private readonly MarketContext _context;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;
        private readonly EmailService _emailService;
        public MercadoService(MarketContext context, IMapper mapper, TokenService tokenService,EmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            _tokenService = tokenService;
            _emailService = emailService;
        }

        public MercadoResponseDTO getMercadoById(int mercadoId)
        {
            try
            {
                var mercado = _context.Mercados.Where(m=> m.Id == mercadoId).FirstOrDefault();
                if (mercado == null) return null;
                return _mapper.Map<MercadoResponseDTO>(mercado);
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
        public List<MercadoResponseDTO> getListMercado()
        {
            try
            {
                var mercados = _context.Mercados.ToList();
                return _mapper.Map<List<MercadoResponseDTO>>(mercados);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Result AtivarMercado(AtivarContaDTO request)
        {
            try
            {
                if (_tokenService.verificaToken(request))
                {
                    var mercado = _context.Mercados.Where(m => m.Id == request.Id).FirstOrDefault();
                    if (mercado == null) return Result.Fail("Mercado não encontrado!");
                    mercado.Ativo = 1;
                    _context.Mercados.Update(mercado);
                    _context.SaveChanges();
                    return Result.Ok().WithSuccess("Mercado ativado com sucesso!");
                }
                return Result.Fail("Token inválido!");
            }catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public Result CadastrarMercado(CadastrarMercadoRequestDTO mercadoDTO)
        {
            try
            {
                if (!verificaEmail(mercadoDTO.Email)) return Result.Fail("Email já existente!");
                var mercado = _mapper.Map<Mercado>(mercadoDTO);
                mercado.Ativo = 0;
                _context.Mercados.Add(mercado);
                _context.SaveChanges();
                var mercadoEmail = new EmailRequestDTO()
                {
                    Id = mercado.Id,
                    Email = mercado.Email,
                    Nome = mercado.NomeMercado
                };
                var token = _tokenService.GeraToken(mercado.Id);
                
                _emailService.enviarEmail(mercadoEmail, "Link de Ativação", token.Value);
                return Result.Ok().WithSuccess("Cadastrado com sucesso!");
            }catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
        private bool verificaEmail(string email)
        {
            try
            {
                var mercado = _context.Mercados.Where(m=> m.Email == email).FirstOrDefault();
                if (mercado != null) return false;
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
        public Result EsqueceuSenhaMercado(EsqueceuSenhaMercaoDTO request)
        {
            throw new NotImplementedException();
        }

        public Result UpdateMercado(UpdateMercadoRequestDTO mercadoDTO)
        {
            try
            {
                var mercado = getMercadoById(mercadoDTO.Id);
                if (mercado == null) return Result.Fail("Mercado não encontrado!");
                mercado.NomeMercado = mercadoDTO.NomeMercado;
                mercado.EnderecoMercado = mercadoDTO.EnderecoMercado;
                mercado.NomeBairro = mercadoDTO.NomeBairro;
                mercado.NumeroEndereco = mercadoDTO.NumeroEndereco;
                var mercadoB = _mapper.Map<Mercado>(mercado); 
                _context.Mercados.Update(mercadoB);
                _context.SaveChanges();
                return Result.Ok().WithSuccess("Mercado Atualizado com sucesso!");
            }
            catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
    }
}
