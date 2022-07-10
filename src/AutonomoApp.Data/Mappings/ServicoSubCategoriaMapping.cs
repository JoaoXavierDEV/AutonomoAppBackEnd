using AutonomoApp.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutonomoApp.Data.Mappings;

public class ServicoSubCategoriaMapping : IEntityTypeConfiguration<ServicoSubCategoria>
{
    public void Configure(EntityTypeBuilder<ServicoSubCategoria> builder)
    {
        builder.HasKey(x => new { x.ServicoId, x.SubCategoriaId });

        builder
            .HasOne(bc => bc.Servico)
            .WithMany(c => c.ServicoSubCategoria)
            .HasForeignKey(bc => bc.ServicoId);
        
        builder
            .HasOne(bc => bc.Subcategoria)
            .WithMany(c => c.ServicoSubCategoria)
            .HasForeignKey(bc => bc.SubCategoriaId);

        builder.ToTable("AAServicoSubCategoria");
    }
}