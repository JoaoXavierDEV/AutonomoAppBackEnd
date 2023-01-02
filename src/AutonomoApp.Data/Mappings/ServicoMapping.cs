using System.ComponentModel;
using AutonomoApp.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutonomoApp.Data.Mappings;

public class ServicoMapping : IEntityTypeConfiguration<Servico>
{
    public void Configure(EntityTypeBuilder<Servico> builder)
    {
        var splitStringConverter = new ValueConverter<IEnumerable<string>, string>(
            v => string.Join(",", v),
            v => v.Split(new[] { ',' }));
        builder.Property(p => p.Tags)
            .HasConversion(splitStringConverter);


        builder
            .HasOne(p => p.Prestador)

            .WithMany();
            // .HasForeignKey(x => x.);


        //.WithMany(x => x.HistoricoDePedidos);


        //builder
        //    .HasOne(p => p.SubCategoria)
        //    .WithMany(x => x.Servicos)
        //    .HasForeignKey(e => e.SubcategoriaId)
        //    .OnDelete(DeleteBehavior.NoAction);

        //builder
        //    .HasOne(p => p.Categoria)
        //    .WithMany(x => x.Servicos)
        //    .HasForeignKey(e => e.Id)
        //    .OnDelete(DeleteBehavior.NoAction);


        //builder
        //    .Property(e => e.Tags)
        //    .HasConversion(
        //        v => string.Join(',', v),
        //        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));



        builder.ToTable("AAServicos");
    }
}

