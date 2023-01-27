using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutonomoApp.Business.Models.Enums;

namespace AutonomoApp.Business.Models; 

public class Conta : EntityBase
{
    public bool UsuarioVerificado { get; set; }
    public bool PremiumAtivo { get; set; }
    public IEnumerable<Beneficio> Benefícios { get; set; } = Enumerable.Empty<Beneficio>();
    public bool PlanoVitalicio { get; set; }
    public bool RenovacaoAutomatica { get; set; }
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

