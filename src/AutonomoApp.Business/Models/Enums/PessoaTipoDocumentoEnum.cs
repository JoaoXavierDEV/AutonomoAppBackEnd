using System.ComponentModel;

namespace AutonomoApp.Business.Models.Enums;

public enum TipoDocumentoEnum
{
    [Description("CPF:")]
    PessoaFisica = 1,
    [Description("CNPJ:")]
    PessoaJuridica = 2
}
