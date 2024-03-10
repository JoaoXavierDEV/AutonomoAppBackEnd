using AutonomoApp.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutonomoApp.Data.Mappings;

public class SubCategoriaMapping : IEntityTypeConfiguration<Subcategoria>
{
    public void Configure(EntityTypeBuilder<Subcategoria> builder)
    {
        //builder.Ignore(p => p.SubCategoriaEnum);
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
             .HasColumnType("varchar(200)");

        builder
            .Property(p => p.Descricao)
            .IsRequired(false)
            .HasColumnType("varchar(500)");

        builder.Property(x => x.SubCategoriaEnum).HasColumnName("EnumId");

        // builder.ToTable("AASubCategorias");
    }
}