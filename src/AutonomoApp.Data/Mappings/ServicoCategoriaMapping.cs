using AutonomoApp.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutonomoApp.Data.Mappings;

public class ServicoCategoriaMapping : IEntityTypeConfiguration<ServicoCategoria>
{
    public void Configure(EntityTypeBuilder<ServicoCategoria> builder)
    {
        builder.HasKey(x => new { x.ServicoId, x.CategoriaId });

        builder
            .HasOne(bc => bc.Servico)
            .WithMany(c => c.ServicoCategoria)
            .HasForeignKey(bc => bc.ServicoId);
        
        builder
            .HasOne(bc => bc.Categoria)
            .WithMany(c => c.ServicosCategoria)
            .HasForeignKey(bc => bc.CategoriaId);

        builder.ToTable("AAServicoCategoria");
    }
}
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
            .HasForeignKey(bc => bc.ServicoId);

        builder.ToTable("AAServicoSubCategoria");
    }
}