using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS.Request.MercadoRequet
{
    public class CadastrarMercadoRequestDTO
    {
        [Required]
        public string NomeMercado { get; set; }
        [Required]
        public string EnderecoMercado { get; set; }
        [Required]
        public string NumeroEndereco { get; set; }
        [Required]
        public string NomeBairro { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Compare("Senha")]
        [Required]
        public string ConfirmarSenha { get; set; }
    }
}
