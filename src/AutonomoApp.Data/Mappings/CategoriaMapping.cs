using System.Security.Cryptography.X509Certificates;
using AutonomoApp.Business.Models;
using AutonomoApp.Business.Models.Enums.SubCategoriaEnum;
using AutonomoApp.Business.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AutonomoApp.Business.Extensions;

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
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .Property(p => p.CategoriaEnum)
            .HasColumnName("EnumId");

        builder.HasData(new Categoria()
        {
            Id = Guid.Parse("1d46cfa5-33f4-448d-b01d-10ef6f09111e"),
            CategoriaEnum = CategoriaEnum.Tecnologia,
            Nome = CategoriaEnum.Tecnologia.GetEnumDescription(),
            Descricao = "Serviços de TI",
            Subcategorias = new List<Subcategoria>{
                        new Subcategoria()
                        {
                            SubCategoriaEnum = (int)Tecnologia.DevenvolvimetoFrontEnd,
                            Nome = Tecnologia.DevenvolvimetoFrontEnd.GetEnumDescription(),
                        },
                        new Subcategoria()
                        {
                            Id = Guid.Parse("9d1ffc68-1595-4d6a-a62c-3d82f1a0bbfb"),
                            SubCategoriaEnum = (int)Tecnologia.DevenvolvimetoBackEnd,
                            Nome = Tecnologia.DevenvolvimetoBackEnd.GetEnumDescription(),
                        },
                        new Subcategoria()
                        {
                            SubCategoriaEnum = (int)Tecnologia.Infra,
                            Nome = Tecnologia.Infra.GetEnumDescription(),
                        },
                        new Subcategoria()
                        {
                            SubCategoriaEnum = (int)Tecnologia.DevOps,
                            Nome = Tecnologia.DevOps.GetEnumDescription(),
                        }
                    }
        },
                new Categoria()
                {
                    CategoriaEnum = CategoriaEnum.ServicosGerais,
                    Nome = CategoriaEnum.ServicosGerais.GetEnumDescription(),
                    Descricao = "Serviços de Limpezae afins",
                    Subcategorias = new List<Subcategoria>()
                    {
                        new Subcategoria()
                        {
                            SubCategoriaEnum = (int)ServicosGerais.Varrer,
                            Nome = ServicosGerais.Varrer.GetEnumDescription()
                        },
                        new Subcategoria()
                        {
                            SubCategoriaEnum = (int)ServicosGerais.LavarLouca,
                            Nome = ServicosGerais.LavarLouca.GetEnumDescription()
                        },
                        new Subcategoria()
                        {
                            SubCategoriaEnum = (int)ServicosGerais.Limpeza,
                            Nome = ServicosGerais.Limpeza.GetEnumDescription()
                        },
                    }
                },
                new Categoria()
                {
                    CategoriaEnum = CategoriaEnum.Lanches,
                    Nome = CategoriaEnum.Lanches.GetEnumDescription(),
                    Descricao = "Peça seu lanche",
                    Subcategorias = new List<Subcategoria>()
                    {
                        new Subcategoria()
                        {
                            SubCategoriaEnum = (int)Lanches.Doces,
                            Nome = Lanches.Doces.GetEnumDescription()
                        },
                        new Subcategoria()
                        {
                            SubCategoriaEnum = (int)Lanches.Pizza,
                            Nome = Lanches.Pizza.GetEnumDescription()
                        },
                        new Subcategoria()
                        {
                            SubCategoriaEnum = (int)Lanches.Restaurantes,
                            Nome = Lanches.Restaurantes.GetEnumDescription()
                        },
                    }

                });



        //builder
        //    .Property(p => p.CategoriaEnum)
        //    .HasColumnName("EnumString")
        //    .HasConversion<string>();



        //builder.ToTable("AACategorias");
    }
}