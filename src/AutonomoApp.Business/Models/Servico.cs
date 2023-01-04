﻿using AutonomoApp.Business.Models.Enums;
using System;
using System.Collections.Generic;

namespace AutonomoApp.Business.Models;

public class Servico : EntityBase
{
    public virtual Pessoa Prestador { get; set; }
    public virtual string Nome { get; set; }
    public virtual string Descricao { get; set; }

    private decimal _valor;
    public virtual decimal Valor
    {
        get
        {
            if (TemDesconto) return PrecoComDesconto();
            return _valor;
        }
        set { _valor = value; }
    }

    public virtual IEnumerable<string> Tags { get; set; }
    public DateTime DataPublicada { get; set; }
    public TipoDeServico TipoDeServico { get; set; }
    public bool AnuncioAtivo { get; set; }
    public bool PermiteParcelamento { get; set; }
    public bool TemDesconto { get; set; }
    public decimal Desconto { get; set; }

    /* EF */
    public virtual Guid CategoriaId { get; set; }
    public virtual IEnumerable<ServicoCategoria>? ServicoCategoria { get; set; }  // = new Categoria();
    public virtual Guid SubcategoriaId { get; set; }
    public virtual IEnumerable<ServicoSubCategoria>? ServicoSubCategoria { get; set; }// = new Subcategoria();

    public Servico()
    {
        DataPublicada = DateTime.Now;
        TemDesconto = false;
        Desconto = 0;
        TipoDeServico = TipoDeServico.CompraUnica;
    }

    public decimal PrecoComDesconto() => Math.Round(_valor - (PercentualDesconto() * _valor), 2);

    public decimal ValorDescontado() => Math.Round(_valor - PrecoComDesconto(), 2);

    private decimal PercentualDesconto() => Desconto / 100;
}