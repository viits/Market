using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS.Response
{
    public class LoginUsuarioResponseDTO
    {
        public int UsuarioId { get; set; }
        public string Token { get; set; }
    }
}
