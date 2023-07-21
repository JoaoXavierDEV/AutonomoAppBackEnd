using AutonomoApp.Business.Models;
using AutonomoApp.Business.Models.Enums;

namespace AutonomoApp.WebApi.ViewModels;
public class ServicoViewModel
{
    public Guid Prestador { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public IEnumerable<string> Tags { get; set; }
    public TipoDeServico TipoDeServico { get; set; }
    public bool AnuncioAtivo { get; set; }
    public bool PermiteParcelamento { get; set; }
    public bool TemDesconto { get; set; }
    public decimal Desconto { get; set; }
    public Guid CategoriaId { get; set; }
    public Guid SubcategoriaId { get; set; }

    public ServicoViewModel(Guid prestador, string nome, string descricao, decimal valor, IEnumerable<string> tags, Guid categoria, Guid subcategoria)
    {
        Prestador = prestador;
        Nome = nome;
        Descricao = descricao;
        Valor = valor;
        Tags = tags;
        CategoriaId = categoria;
        SubcategoriaId = subcategoria;
    }
    public ServicoViewModel()
    {
        
    }
}

