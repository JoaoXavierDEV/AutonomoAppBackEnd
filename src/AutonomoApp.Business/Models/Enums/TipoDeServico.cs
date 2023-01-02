using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomoApp.Business.Models.Enums;

public enum TipoDeServico
{
    [Description("Compra única")]
    CompraUnica = 1,
    [Description("Assinatura Mensal")]
    AssinaturaMensal = 2,
    [Description("Assinatura Anual")]
    AssinaturaAnual = 3,

}
