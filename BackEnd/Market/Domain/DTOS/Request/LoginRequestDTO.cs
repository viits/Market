using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS.Request
{
    public class LoginRequestDTO
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
