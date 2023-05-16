using Domain.DTOS.Request;
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
        Result LoginMercado(LoginRequestDTO login);
        Result LoginUsuario(LoginRequestDTO login);
    }
}
