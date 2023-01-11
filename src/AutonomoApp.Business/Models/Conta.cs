using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomoApp.Business.Models;

public class Conta : EntityBase
{
    public bool UsuarioVerificado { get; set; }
    public bool PremiumAtivo { get; set; }
    public IEnumerable<Beneficio> Benefícios { get; set; } = Enumerable.Empty<Beneficio>();
    public bool PlanoVitalicio { get; set; }
    public bool renovacaoAutomatica { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }

    public Conta()
    {
        Beneficio InicialBeneficio = new Beneficio
        {
            Nome = "Avaliação de 30 dias",
            Codigo = "trial",
            Descricao = "Avaliação inicial de 30 dias para novos usuários",
            TipoDeBeneficio = TipoDeBeneficio.Avaliacao,
        };

        Benefícios = Benefícios.Append(InicialBeneficio);
    }
}


public class Beneficio : EntityBase
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Codigo { get; set; }
    public TipoDeBeneficio TipoDeBeneficio { get; set; }
}

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

