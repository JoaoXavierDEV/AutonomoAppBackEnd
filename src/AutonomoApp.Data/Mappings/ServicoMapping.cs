using System.ComponentModel;
using AutonomoApp.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace AutonomoApp.Data.Mappings
{



    public class ServicoMapping : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {

            var splitStringConverter = new ValueConverter<IEnumerable<string>, string>(
                  v => string.Join(",", v.Where(x => !string.IsNullOrWhiteSpace(x)).ToList()),
                  v => v.Replace(" ", string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries).Where(x => x != "").ToList());

            builder.Property(p => p.Tags)
                .HasConversion(splitStringConverter);

            // TODO: mudar nome da propriedade
            builder
                .HasOne(p => p.ClientePrestador)
                .WithMany()
                .OnDelete(deleteBehavior: DeleteBehavior.ClientCascade);
                
            ///.HasConstraintName("ClientId");


            builder
                .HasOne(p => p.Categoria)
                .WithMany()
                .OnDelete(deleteBehavior: DeleteBehavior.ClientCascade);

            builder
                .HasOne(x => x.Subcategoria)
                .WithMany()
                .OnDelete(deleteBehavior: DeleteBehavior.ClientCascade);

            //builder
            //    .HasOne(p => p.SubCategoria)
            //    .WithMany(x => x.Servicos)
            //    .HasForeignKey(e => e.SubcategoriaId)
            //    .OnDelete(DeleteBehavior.NoAction);





            builder.ToTable("AAServicos");
        }
    }

}