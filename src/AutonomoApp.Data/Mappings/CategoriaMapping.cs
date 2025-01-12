using System.Security.Cryptography.X509Certificates;
using AutonomoApp.Business.Models;
using AutonomoApp.Business.Models.Enums.SubCategoriaEnum;
using AutonomoApp.Business.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AutonomoApp.Framework;

namespace AutonomoApp.Data.Mappings;

public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Nome)
            .HasColumnName("Nome")
            .HasColumnType("varchar(200)");

        builder
            .Property(p => p.Descricao)
            .IsRequired(false)
            .HasColumnType("varchar(500)");

        builder
            .HasMany(p => p.Subcategorias)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .Property(p => p.CategoriaEnum)
            .HasColumnName("EnumId");

        //builder
        //    .Property(p => p.CategoriaEnum)
        //    .HasColumnName("EnumString")
        //    .HasConversion<string>();



        //builder.ToTable("AACategorias");
    }
}