﻿using Domain.DTOS.Request;
using Domain.Model;
using FluentResults;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Result enviarEmail(EmailRequestDTO dto, string assunto, string token)
        {
            try
            {
                var mensagem = new Mensagem(dto, assunto, token);
                var mensagemEmail = CorpoMensagem(mensagem);
                EnviarMensagem(mensagemEmail);
                return Result.Ok();

            }catch (Exception ex)
            {
                return Result.Fail("Erro ao enviar o email!");
            }
        }
        //CRIANDO O CORPO DA MENSAGEM
        private MimeMessage CorpoMensagem(Mensagem email)
        {
            var mensagemEmail = new MimeMessage();
            mensagemEmail.From.Add(new MailboxAddress(_configuration["EmailSettings:Name"], _configuration["EmailSettings:From"]));
            mensagemEmail.To.Add(email.Destinatario);
            mensagemEmail.Subject = email.Assunto;
            mensagemEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = email.Conteudo
            };
            return mensagemEmail;
        }
        private void EnviarMensagem(MimeMessage mensagem)
        {
            using (var cliente = new SmtpClient())
            {
                try
                {
                    cliente.Connect(
                    _configuration["EmailSettings:SmtpServer"],
                    Convert.ToInt32(_configuration["EmailSettings:Port"]),
                    MailKit.Security.SecureSocketOptions.StartTls
                    );
                    cliente.AuthenticationMechanisms.Remove("XOUATH2");
                    cliente.Authenticate(_configuration["EmailSettings:From"],
                        _configuration["EmailSettings:Password"]
                    );
                    cliente.Send(mensagem);
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    cliente.Disconnect(true);
                    cliente.Dispose();
                }
            };
        }
    }
}
