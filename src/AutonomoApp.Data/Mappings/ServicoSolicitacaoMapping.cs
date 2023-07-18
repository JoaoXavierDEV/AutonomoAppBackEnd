using AutonomoApp.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutonomoApp.Data.Mappings;

public class ServicoSolicitacaoMapping : IEntityTypeConfiguration<ServicoSolicitado>
{
    public void Configure(EntityTypeBuilder<ServicoSolicitado> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasOne(p => p.Servico);
        builder.HasOne(p => p.ClienteSolicitante);
        // builder.ToTable("AAHistoricoDePedidos");
    }
}