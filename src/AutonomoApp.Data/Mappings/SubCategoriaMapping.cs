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

        //builder.Property(p => p.Id).ValueGeneratedOnAdd();
        
        builder.Property(p => p.Nome);
        builder
            .Property(p => p.Descricao)
            .IsRequired(false)
            .HasColumnType("varchar(150)");


        builder
            .HasOne(x => x.Categoria)
            .WithMany(x => x.Subcategorias)
            //.HasForeignKey(x => x.CategoriaId)
            /////.HasConstraintName("FKCategoria")
            ;


        builder.Property(x => x.SubCatEnumId).HasColumnName("NMEnum");

        builder.ToTable("AASubCategorias");
    }
}