using System;
using System.Collections.Generic;
using AutonomoApp.Business.Models;

namespace AutonomoApp.Business.DTO;
public record struct ServicoDTO
{
    public Guid Prestador { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public IEnumerable<string> Tags { get; set; }
    public Guid Categoria { get; set; }
    public Guid Subcategoria { get; set; }

    public ServicoDTO(Guid prestador, string nome, string descricao, decimal valor, IEnumerable<string> tags, Guid categoria, Guid subcategoria)
    {
        Prestador = prestador;
        Nome = nome;
        Descricao = descricao;
        Valor = valor;
        Tags = tags;
        Categoria = categoria;
        Subcategoria = subcategoria;
    }

    public Servico ToModel()
    {
        return new Servico()
        {
            Nome = Nome,
            Descricao = Descricao,
            Valor = Valor,
            Tags = Tags,
        };
    }
}

