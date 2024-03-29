﻿using System;
using System.Threading.Tasks;
using AutonomoApp.Business.DTO;
using AutonomoApp.Business.Models;

namespace AutonomoApp.Business.Interfaces.IService;

public interface IServicoService
{
    Task<ServicoDTO> ObterServicoDTO(Guid id);
    Task ValidarServico(Servico servico);
}