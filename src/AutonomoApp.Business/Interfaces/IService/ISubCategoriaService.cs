using AutonomoApp.Business.Models;
using System.Threading.Tasks;

namespace AutonomoApp.Business.Interfaces.IService;

public interface ISubCategoriaService
{
    Task Adicionar(Subcategoria subcategoria);
    Task Atualizar(Subcategoria subcategoria);
}