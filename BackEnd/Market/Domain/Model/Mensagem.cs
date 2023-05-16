using Domain.DTOS.Request;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Mensagem
    {
        public Mensagem(EmailRequestDTO usuarioDto, string assunto, string token)
        {
            this.Destinatario = new MailboxAddress(usuarioDto.Nome, usuarioDto.Email);
            this.Assunto = assunto;
            this.Conteudo = $"usuarioId={usuarioDto.Id} CodigoAtivacao={token}";
        }
        public MailboxAddress Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }
    }
}
