using Domain.DTOS.Request;
using Domain.DTOS.Response;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ILogin
    {
        LoginResponseDTO LoginMercado(LoginRequestDTO login);
        LoginUsuarioResponseDTO LoginUsuario(LoginRequestDTO login);
    }
}
