using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS.Request
{
    public class CadastrarListaRequestDTO
    {
        [Required]
        public string NomeLista { get; set; }
        [Required]
        public int QuantidadeProduto { get; set; }
        [Required]
        public int CdProduto { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public int MercadoId { get; set; }
    }
}
