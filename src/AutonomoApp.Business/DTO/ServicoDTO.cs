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

    /* EF */
    public Guid CategoriaId { get; set; }
    public Guid SubcategoriaId { get; set; }

    // teste not mapped
    public Categoria? Categoria { get; set; }
    public Subcategoria? Subcategoria { get; set; }

    public ServicoDTO(Pessoa cliente, string nome, string descricao, decimal valor, IEnumerable<string> tags, Guid categoriaId, Guid subcategoriaId, Categoria? categoria, Subcategoria? subcategoria)
    {
        Cliente = cliente;
        Nome = nome;
        Descricao = descricao;
        Valor = valor;
        Tags = tags;
        CategoriaId = categoriaId;
        SubcategoriaId = subcategoriaId;
        Categoria = categoria;
        Subcategoria = subcategoria;
    }

    private Categoria GetCategoria()
    {
        // acessar
        return new Categoria();
    }
}

