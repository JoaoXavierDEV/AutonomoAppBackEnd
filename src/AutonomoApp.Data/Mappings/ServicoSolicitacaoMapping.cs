using AutonomoApp.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutonomoApp.Data.Mappings;

public class ServicoSolicitacaoMapping : IEntityTypeConfiguration<ServicoSolicitacao>
{
    public void Configure(EntityTypeBuilder<ServicoSolicitacao> builder)
    {
        builder.HasKey(p => p.Id);
        builder.ToTable("AAHistoricoDePedidos");
    }
}