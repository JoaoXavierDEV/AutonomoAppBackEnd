using System.Security.Cryptography.X509Certificates;
using AutonomoApp.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutonomoApp.Data.Mappings;

public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Nome)
            .HasColumnName("Nome")
            .HasColumnType("varchar(20)");

        builder
            .Property(p => p.Descricao)
            .IsRequired(false)
            .HasColumnType("varchar(150)");

        builder
            .HasMany(p => p.Subcategorias)
            .WithOne(x => x.Categoria);
         //   .HasForeignKey("FKCategoria"); // TODO aqui define a shadow

        //builder
        //    .HasMany(p => p.ServicosCategoria)
        //      .WithOne(x => x.Categoria);
        //    //.HasForeignKey(x => x.CategoriaId)
        //     //   .HasConstraintName("FKCategoriaaaa");
        //    //.OnDelete(DeleteBehavior.NoAction);

        builder
            .Property(p => p.CategoriaEnum)
            .HasColumnName("EnumId");



        //builder
        //    .Property(p => p.CategoriaEnum)
        //    .HasColumnName("EnumString")
        //    .HasConversion<string>();



        builder.ToTable("AACategorias");
    }
}