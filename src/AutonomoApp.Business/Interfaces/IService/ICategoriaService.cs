using AutonomoApp.Business.Models;
using System.Threading.Tasks;

namespace AutonomoApp.Business.Interfaces.IService;

public interface ICategoriaService
{
    Task Adicionar(Categoria categoria);
    Task Atualizar(Categoria categoria);
}