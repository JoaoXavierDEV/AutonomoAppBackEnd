using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutonomoApp.Framework;
using AutonomoApp.Business.Interfaces;
using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Interfaces.IService;
using AutonomoApp.Business.Models;
using AutonomoApp.Business.Models.Enums;
using AutonomoApp.Business.Models.Enums.SubCategoriaEnum;
using AutonomoApp.Business.Models.Validations;
using AutonomoApp.Business.Notificacoes;

namespace AutonomoApp.Business.Services;

public class CategoriaService : BaseService, ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;


    public CategoriaService(ICategoriaRepository categoriaRepository,
        INotificador notificador) : base(notificador)
    {
        _categoriaRepository = categoriaRepository;
    }


    public async Task Adicionar(Categoria categoria)
    {
        // if (categoria.Nome.Length < 5) throw new ArgumentNullException("Exce");

        // if (!ExecutarValidacao(new CategoriaValidation(), categoria)) return; // funcionando

        Validar(categoria);

        /* TRANSACTION
         * A.C.I.D.
         * ATOMICIDADE - faz tudo, ou não faz nada // trans.rollback
         * CONSISTENCIA - dados devem ser válidos
         * ISOLAMENTO - uma transação deve ser isolada de outras
         * DURABILIDADE - garante que os dados sejam persistidos // commit
         */

        try
        {
            await _categoriaRepository.Adicionar(categoria);

        }
        catch (Exception)
        {

            throw;
        }

    }
    public async Task Atualizar(Categoria categoria)
    {
        Validar(categoria);

        await _categoriaRepository.Adicionar(categoria);
    }

    private void Validar(Categoria categoria)
    {
        if (!ExecutarValidacao(new CategoriaValidation(), categoria)) return;

        if (_categoriaRepository.ObterPorId(categoria.Id).Result != null)
        {
            Notificar("Já existe uma Categoria com o mesmo ID");
            return;
        }

        if (_categoriaRepository.Consultar().Count(x => x.Nome == categoria.Nome) > 0)
        {
            Notificar("Já existe uma Categoria com o mesmo nome");
            return;
        }
    }

    public async Task Remover(Guid id)
    {
        await _categoriaRepository.Remover(id);
    }


    public void Dispose()
    {
        _categoriaRepository?.Dispose();
    }

}

public class CategoriaBuilder
{
    public int Categoria { get; }
    public int SubCategoria { get; }

    public Enum CategoriaNome { get; }
    public Enum SubCategoriaNome { get; }

    public CategoriaBuilder(int categoria, int subCategoria)
    {
        // Validar(categoria, subCategoria);
        Validar(categoria, subCategoria);
        // nao mexer
        Categoria = categoria;
        SubCategoria = subCategoria;

        //
        CategoriaNome = (CategoriaEnum)categoria;
        SubCategoriaNome = RetornarTipoEnum((CategoriaEnum)categoria);
    }

    public Enum RetornarTipoEnum(CategoriaEnum categoria)
    {
        var nomeEnum = ObterListaDeEnums().First(x => x.Name == categoria.ToString());
        return (Enum)Enum.ToObject(nomeEnum, SubCategoria);
    }

    private static void Validar(int catParam, int subParam)
    {
        // Verifica se o Enum existe dentro do Range
        if (!Enum.IsDefined(typeof(CategoriaEnum), catParam))
            throw new ArgumentException(message: "Número de categoria inválido", paramName: nameof(catParam));
        // Cria o CatEnum
        var categoria = Enum.ToObject(typeof(CategoriaEnum), catParam);
        // Pega o SubEnum onde o nome é igual a Categoria
        var tt = ObterListaDeEnums().ToList();
        var subCategoria = ObterListaDeEnums().FirstOrDefault(x => x.Name == categoria.ToString());
        if (subCategoria == null)
            throw new ArgumentException("SubCategoria não cadastrada");
        // Verifica se o SubEnum existe dentro do Range
        if (!Enum.IsDefined(subCategoria, subParam))
            throw new ArgumentException(message: "Número de SubCategoria inválido", paramName: nameof(subParam));
    }

    private static IEnumerable<Type> ObterListaDeEnums()
    {
        var asm = Assembly.GetExecutingAssembly();
        const string nameSpaceEnums = "AutonomoApp.Business.Models.Enums.SubCategoriaEnum";

        return asm.GetTypes()
            .Where(t
                => String.Equals(t.Namespace, nameSpaceEnums,
                    StringComparison.Ordinal)
                );
    }
    public Dictionary<string, string> GetDictionary()
    {
        return new Dictionary<string, string>
        {
            {"IdCategoria:",  Categoria.ToString()},
            {"IdSubCategoria",  SubCategoria.ToString()},
            {"Categoria" , CategoriaNome.GetEnumDescription()},
            {"SubCategoria" ,SubCategoriaNome.GetEnumDescription()}
        };
    }

    public override string ToString()
    {
        // object[] args = { Categoria.ToString(), SubCategoria.ToString(), CategoriaNome,SubCategoriaNome };
        return String.Format($"IdCategoria:  {Categoria} " +
                             $"\nIdSubCategoria:  {SubCategoria} " +
                             $"\nCategoria: {CategoriaNome.GetEnumDescription()}" +
                             $" \nSubCategoria: {SubCategoriaNome.GetEnumDescription()}");
    }
}
