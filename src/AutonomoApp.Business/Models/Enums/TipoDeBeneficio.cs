using System.ComponentModel;

namespace AutonomoApp.Business.Models.Enums;

public enum TipoDeBeneficio
{
    [Description("Avaliação de 30 dias")]
    Avaliacao = 1,
    [Description("Exibir 3x no Topo por dia")]
    ExibirTopo3,
    [Description("Exibir 5x no Topo por dia")]
    ExibirTopo5,
    [Description("Exibir 10x no Topo por dia")]
    ExibirTopo10,
}

