using Domain.DTOS.Request;
using Domain.DTOS.Request.UsuarioRequest;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IUsuario
    {
        Result CadastrarUsuario(CadastrarUsuarioRequestDTO usuarioDTO);
        Result AtivarUsuario(AtivarContaDTO request);
    }
}
