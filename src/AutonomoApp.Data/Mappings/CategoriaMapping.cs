using AutonomoApp.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutonomoApp.Data.Mappings;

public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("Id");

        builder
            .Property(p => p.Nome)
            .HasColumnName("Nome")
            .HasColumnType("varchar(20)");

        builder.Property(p => p.IdEnum)
            .HasColumnName("IdEnum");

        //builder
        //    .Property(p => p.CategoriaEnum)
        //    .HasColumnName("EnumString")
        //    .HasConversion<string>();


        builder
            .Property(p => p.Descricao)
            .IsRequired(false)
            .HasColumnType("varchar(150)");

        builder.ToTable("Categorias");
    }
}