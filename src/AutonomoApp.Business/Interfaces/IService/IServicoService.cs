using System;
using System.Threading.Tasks;
using AutonomoApp.Business.DTO;

namespace AutonomoApp.Business.Interfaces.IService;

public interface IServicoService
{
    Task<ServicoDTO> ObterServicoDTO(Guid id);
}