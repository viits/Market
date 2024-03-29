﻿using Domain.DTOS.Request;
using Domain.DTOS.Request.MercadoRequet;
using Domain.DTOS.Response.MercadoResponse;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IMercado
    {
        Result CadastrarMercado(CadastrarMercadoRequestDTO mercadoDTO);
        Result UpdateMercado(UpdateMercadoRequestDTO mercadoDTO);
        MercadoResponseDTO getMercadoById(int id);
        List<MercadoResponseDTO> getListMercado();
        Result AtivarMercado(AtivarContaDTO request);
        Result EsqueceuSenhaMercado(EsqueceuSenhaMercaoDTO request);
    }
}
