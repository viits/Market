using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS.Response.ListaResponse
{
    public class CompararListaResponseDTO
    {
        public CompararListaResponseDTO(List<ListaResponseDTO> mercado1, List<ListaResponseDTO> mercado2)
        {
            this.MercadoLista = mercado1;
            this.MercadoComparar = mercado2;
        }
        public List<ListaResponseDTO> MercadoLista { get; set; }
        public List<ListaResponseDTO> MercadoComparar { get; set; }
    }
}
