using System;
using System.Collections.Generic;
using AutonomoApp.Business.Models;

namespace AutonomoApp.Business.DTO;


public record struct ServicoDTO
{
    public Pessoa Cliente { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public IEnumerable<string> Tags { get; set; }
    public CategoriaDto Categoria { get; set; }
    public SubCategoriaDto Subcategoria { get; set; }

    public ServicoDTO(Pessoa cliente, 
        string nome, string descricao, 
        decimal valor, IEnumerable<string> tags,
        CategoriaDto categoria,
        SubCategoriaDto subcategoria)
    {
        Cliente = cliente;
        Nome = nome;
        Descricao = descricao;
        Valor = valor;
        Tags = tags;
        Categoria = categoria;
        Subcategoria = subcategoria;
    }
}

