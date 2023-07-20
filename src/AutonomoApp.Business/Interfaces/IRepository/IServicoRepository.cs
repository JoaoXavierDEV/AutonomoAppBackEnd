using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutonomoApp.Business.DTO;
using AutonomoApp.Business.Models;

namespace AutonomoApp.Business.Interfaces.IRepository;

public interface IServicoRepository : IRepository<Servico>
{
    Task<List<Servico>> ObterTodosServicos();
    Task<Servico> ObterServicoPorUsuario(Guid id);
    Task CadastrarServico(ServicoDTO servico);
}