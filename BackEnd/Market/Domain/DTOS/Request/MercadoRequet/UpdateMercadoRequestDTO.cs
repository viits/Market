using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS.Request.MercadoRequet
{
    public class UpdateMercadoRequestDTO
    {
        [Required]
        public int Id { get; set; }
        public string ImagemMercado { get; set; }
        public string CEP { get; set; }
        public string NomeMercado { get; set; }
        public string EnderecoMercado { get; set; }
        public string NumeroEndereco { get; set; }
        public string NomeBairro { get; set; }
    }
}
