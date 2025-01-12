using AutonomoApp.Business.Models.Enums;
using AutonomoApp.Framework;
using System.ComponentModel.DataAnnotations;

namespace AutonomoApp.Business.Models;

public class Servico : EntityBase
{
    
    public virtual Guid ClientePrestadorId { get; private set; }
    public virtual Pessoa ClientePrestador { get; private set; }

    public void AddClientePrestador(Pessoa clientePrestador)
    {
        ClientePrestador = clientePrestador;

    }

    public virtual Guid CategoriaId { get; private set; }
    public virtual Categoria Categoria { get; private set; }
    public virtual Guid SubcategoriaId { get; private set; }
    public virtual Subcategoria Subcategoria { get; private set; }







    public virtual string Nome { get; set; }
    public virtual string Descricao { get; set; }

    public virtual IEnumerable<string> Tags { get; set; } = Enumerable.Empty<string>();
    public DateTime? DataPublicada { get; set; }
    public TipoDeServico TipoDeServico { get; set; } = TipoDeServico.CompraUnica;
    public bool AnuncioAtivo { get; set; }
    public bool PermiteParcelamento { get; set; }


    /// <summary>
    /// Percentual de desconto para cálculo - Desconto 50% Percentual 0.5
    /// </summary>
    private decimal PercentualDesconto => (Desconto / 100).Round();

    /// <summary>
    /// Valor do produto - Pesistível
    /// </summary>
    private decimal _valor = 0m;

    /// <summary>
    /// Valor do Serviço calculado - Não é salvo no banco
    /// Não persistivel 
    /// </summary>
    /// <value>Propriedade calculada</value>
    public virtual decimal Valor
    {
        get { return AplicaDesconto ? PrecoComDesconto : _valor; }
        set => _valor = value;
    }

    /// <summary>
    /// Desconto pode ser habilitado 
    /// </summary>
    public bool AplicaDesconto { get; set; } = false;
    /// <summary>
    /// Percentual de desconto à ser aplicado caso a Flag "AplicaDesconto" seja habilitada.
    /// </summary>
    public decimal Desconto { get; set; } = 0;



    public decimal PrecoComDesconto => Math.Round(_valor - (PercentualDesconto * _valor), 2);

    public decimal ValorDescontado => Math.Round(_valor - PercentualDesconto, 2);




    public Servico(string nome,
                   string descricao,
                   Guid prestador,
                   Guid Categoria,
                   Guid subcategoria,
                   List<string> tags,
                   decimal valor,
                   bool habilitarDesconto,
                   decimal desconto,
                   bool permiteParcelamento,
                   bool anuncioAtivo = true)
    {
        Nome = nome;
        Descricao = descricao;
        AplicaDesconto = habilitarDesconto;
        Desconto = desconto;
        
        ClientePrestadorId = prestador;
        CategoriaId = Categoria;
        SubcategoriaId = subcategoria;
        AnuncioAtivo = anuncioAtivo;
        Valor = valor;

        if (tags.Count != 0)
        {
            Tags = tags;
        }

        if (AnuncioAtivo)
        {
            DataPublicada = DateTime.Today;
        }

    }

    public Servico()
    {
        
    }


}