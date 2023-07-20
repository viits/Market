using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS.Response.MercadoResponse
{
    public class MercadoResponseDTO
    {
        public int Id { get; set; }
        public string NomeMercado { get; set; }
        public string ImagemMercado { get; set; }
        public string CEP { get; set; }
        public string EnderecoMercado { get; set; }
        public string NumeroEndereco { get; set; }
        public string NomeBairro { get; set; }
        public string Email { get; set; }
    }
}
