using AutonomoApp.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutonomoApp.Data.Mappings;

public class ServicoCategoriaMapping : IEntityTypeConfiguration<ServicoCategoria>
{
    public void Configure(EntityTypeBuilder<ServicoCategoria> builder)
    {
        // builder.HasKey(x => new { x.ServicoId, x.CategoriaId });

        builder
            .HasOne(bc => bc.Servico)
            .WithMany(c => c.ServicoCategoria)
            .HasForeignKey(bc => bc.ServicoId)
            .HasConstraintName("FKServico");
        // quando vc seta a FK ela cria uma propriedade sombra
        // nessa classe as chaves FK foram duplicadas - na classe e shadow
        builder
            .HasOne(bc => bc.Categoria)
            .WithMany(c => c.ServicosCategoria)
            .HasForeignKey(bc => bc.CategoriaId)
            .HasConstraintName("FKCategoriaAas");

        builder.ToTable("AAServicoCategoria");
    }
}