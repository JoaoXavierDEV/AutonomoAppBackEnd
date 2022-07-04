using System.ComponentModel;

namespace AutonomoApp.Business.Models.Enums;

public enum CategoriaEnum
{
    [Description("Tecnologia")]
    Tecnologia = 1,
    [Description("Serviços Gerais")]
    ServicosGerais = 2,
    [Description("Lanches")]
    Lanches = 3,
    [Description("Transporte")]
    Transporte = 4,
    [Description("Vendas")]
    Vendas = 5,
    [Description("Maquiagem e afins")]
    Barbearias = 6,
    [Description("Faz de tudo")]
    Tudo = 7,
}