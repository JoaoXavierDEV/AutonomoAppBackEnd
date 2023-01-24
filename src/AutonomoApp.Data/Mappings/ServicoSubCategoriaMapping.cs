using AutonomoApp.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutonomoApp.Data.Mappings;

public class ServicoSubCategoriaMapping : IEntityTypeConfiguration<ServicoSubCategoria>
{
    public void Configure(EntityTypeBuilder<ServicoSubCategoria> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(bc => bc.Servico)
            .WithMany(c => c.ServicoSubCategoria)
            .HasForeignKey(bc => bc.ServicoId);
            //.HasConstraintName("FKServicoIDDD");

        builder
            .HasOne(bc => bc.Subcategoria)
            .WithMany(c => c.ServicoSubCategoria)
            .HasForeignKey(bc => bc.SubCategoriaId);
            //.HasConstraintName("FKCategoriaIDDD");

        builder.ToTable("AAServicoSubCategoria");
    }
}