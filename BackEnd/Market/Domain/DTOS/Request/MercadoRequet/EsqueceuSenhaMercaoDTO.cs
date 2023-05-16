using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS.Request.MercadoRequet
{
    public class EsqueceuSenhaMercaoDTO
    {
        [Required] 
        public int Id { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        [Compare("Senha")]
        public string ConfirmarSenha { get; set; }
    }
}
