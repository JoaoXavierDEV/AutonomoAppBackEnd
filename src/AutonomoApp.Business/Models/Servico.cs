using System.Collections.Generic;

namespace AutonomoApp.Business.Models;

public class Servico : EntityBase
{
    public Pessoa Cliente { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public virtual List<Categoria> Categoria { get; set; }

}