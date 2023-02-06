using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutonomoApp.Business.Extensions;
using AutonomoApp.Business.Interfaces;
using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Interfaces.IService;
using AutonomoApp.Business.Models;
using AutonomoApp.Business.Models.Enums;
using AutonomoApp.Business.Models.Enums.SubCategoriaEnum;
using AutonomoApp.Business.Models.Validations;
using AutonomoApp.Business.Notificacoes;

namespace AutonomoApp.Business.Services;

public class SubCategoriaService : BaseService, ISubCategoriaService
{
    private readonly ISubCategoriaRepository _subcategoriaRepository;


    public SubCategoriaService(ISubCategoriaRepository subcategoriaRepository,
        INotificador notificador) : base(notificador)
    {
        _subcategoriaRepository = subcategoriaRepository;
    }


    public async Task Adicionar(Subcategoria subcategoria)
    {
        // if (categoria.Nome.Length < 5) throw new ArgumentNullException("Exce");

        if (!ExecutarValidacao(new SubCategoriaValidation(), subcategoria))  return;
        
        await _subcategoriaRepository.Adicionar(subcategoria);
    }
    public async Task Atualizar(Subcategoria subcategoria)
    {
        if (!ExecutarValidacao(new SubCategoriaValidation(), subcategoria))  return;

        if (_subcategoriaRepository.ObterPorId(subcategoria.Id).Result != null)
        {
            Notificar("Já existe uma Categoria com o mesmo ID");
            return;
        }
        
        if (_subcategoriaRepository.Consultar().Count(x => x.Nome == subcategoria.Nome) > 0)
        {
            Notificar("Já existe uma Categoria com o mesmo nome");
            return;
        }
        
        await _subcategoriaRepository.Adicionar(subcategoria);
    }

    


    public async Task Remover(Guid id)
    {
        await _subcategoriaRepository.Remover(id);
    }

    public void Dispose()
    {
        _subcategoriaRepository?.Dispose();
    }
}
