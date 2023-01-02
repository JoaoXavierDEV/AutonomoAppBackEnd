using AutonomoApp.Business.Models.Enums;

namespace AutonomoApp.Business.Models;

public class PessoaJuridica : Pessoa
{
    public string NomeEmpresa { get; set; }

    public PessoaJuridica()
    {
        TipoDocumento = Enums.TipoDocumentoEnum.PessoaJuridica;
    }
}