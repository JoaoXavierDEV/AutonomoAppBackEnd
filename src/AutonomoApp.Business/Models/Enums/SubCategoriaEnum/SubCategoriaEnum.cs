using System.ComponentModel;
namespace AutonomoApp.Business.Models.Enums.SubCategoriaEnum;

public enum Tecnologia
{
    [Description("Desenvolvimento Front-End")]
    DevenvolvimetoFrontEnd = 1,
    [Description("Desenvolvimento Back-End")]
    DevenvolvimetoBackEnd = 2,
    [Description("Infraestrutura")]
    Infra = 3,
    [Description("DevOps")]
    DevOps = 4,
}

public enum ServicosGerais
{
    [Description("Varrer memo")]
    Varrer = 1,
    Limpeza = 2,
    LavarLouca = 3,
}

public enum Lanches
{
    Pizza = 1,
    Restaurantes = 2,
    Doces = 3,
}

public enum Transporte
{
    Frete = 1,
    Turismo,
    MotoTaxi
}


