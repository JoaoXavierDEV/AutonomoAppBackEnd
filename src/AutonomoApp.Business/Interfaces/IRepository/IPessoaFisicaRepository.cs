using AutonomoApp.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomoApp.Business.Interfaces.IRepository;

public interface IPessoaFisicaRepository : IRepository<PessoaFisica>
{
    List<PessoaFisica> BuscarPorNome(string nome);
    
}
