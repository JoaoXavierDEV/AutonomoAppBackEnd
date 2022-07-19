using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using AutonomoApp.Business.Interfaces.IRepository;
using AutonomoApp.Business.Models.Enums;
using AutonomoApp.Business.Models.Enums.SubCategoriaEnum;

namespace AutonomoApp.Business.Services;

public class CategoriaService : BaseService
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaService(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
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

    public override string ToString()
    {
        // object[] args = { Categoria.ToString(), SubCategoria.ToString(), CategoriaNome,SubCategoriaNome };
        return String.Format($"IdCategoria:  {Categoria} " +
                             $"\nIdSubCategoria:  {SubCategoria} " +
                             $"\nCategoria: {CategoriaNome}" +
                             $" \nSubCategoria: {SubCategoriaNome}");
    }
}

// TODO: Terminar o Inserir Dados
// TODO: CategoriaBuilder pode ser o CategoriaDTO
// TODO: Desenhar o fluxo de dados dessa bagaçaaaaaaaaa