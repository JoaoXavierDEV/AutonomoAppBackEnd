using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutonomoApp.Business.Models.Enums;

namespace AutonomoApp.Business.Models; 

public class Conta : EntityBase
{
    public bool UsuarioVerificado { get; set; } = false;
    public bool PremiumAtivo { get; set; } = false;
    // TODO Benefícios devem ser fixos, fazer da forma como a categoria se junta com o Serviço
    public ICollection<Beneficio> Benefícios { get; set; } = new Collection<Beneficio>();
    public bool PlanoVitalicio { get; set; } = false;
    public bool RenovacaoAutomatica { get; set; } = false;
    public DateTime DataInicio { get; set; } = DateTime.UtcNow;
    public DateTime? DataFim { get; set; } 

    public Conta()
    {
        UsuarioVerificado = false;
        PremiumAtivo = false;
        PlanoVitalicio = false;
        RenovacaoAutomatica = false;
        DataInicio = DateTime.UtcNow;
        Beneficio InicialBeneficio = new()
        {
            Nome = "Avaliação de 30 dias",
            Codigo = "trial",
            Descricao = "Avaliação inicial de 30 dias para novos usuários",
            TipoDeBeneficio = TipoDeBeneficio.Avaliacao,
        };

        Benefícios.Add(InicialBeneficio);
    }
}

