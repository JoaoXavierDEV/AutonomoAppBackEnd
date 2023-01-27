using AutonomoApp.Business.Models.Enums;

namespace AutonomoApp.Business.Models;

public class Beneficio : EntityBase
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Codigo { get; set; }
    public TipoDeBeneficio TipoDeBeneficio { get; set; }
}

