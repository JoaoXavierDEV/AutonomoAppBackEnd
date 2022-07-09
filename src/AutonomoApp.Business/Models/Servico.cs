using System;
using System.Collections;
using System.Collections.Generic;

namespace AutonomoApp.Business.Models;

public class Servico : EntityBase
{
    public virtual Pessoa Cliente { get; set; }
    public virtual string Nome { get; set; }
    public virtual string Descricao { get; set; }
    public virtual decimal Valor { get; set; }
    public virtual IEnumerable<string>? Tags { get; set; }

    /* EF */
    public virtual Guid CategoriaId { get; set; }
    public virtual IEnumerable<ServicoCategoria>? ServicoCategoria { get; set; }  // = new Categoria();
    public virtual Guid SubcategoriaId { get; set; } 
    public virtual IEnumerable<Subcategoria>? SubCategoria { get; set; }// = new Subcategoria();

}