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

            var splitStringConverter1 = new ValueConverter<IEnumerable<string>, string>(
                  v => string.Join(",", v.Where(x => !string.IsNullOrWhiteSpace(x)).ToList()),
                  v => v.Replace(" ", string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries).Where(x => x != "").ToList());

            var splitStringConverter = new ValueConverter<IEnumerable<string>, string>(
                v => string.Join(",", v),
                v => v.Split(",", StringSplitOptions.RemoveEmptyEntries));
            
            var splitStringConverter3 = new ValueConverter<IEnumerable<string>, string>(
                v => string.Join(",", v),
                v => v.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList());

            builder.Property(p => p.Tags)
                .HasConversion(splitStringConverter3) ;

            builder
                .HasOne(p => p.ClientePrestador)
                .WithMany()
                .OnDelete(deleteBehavior: DeleteBehavior.ClientCascade);
                
            builder
                .HasOne(p => p.Categoria)
                .WithMany()
                .OnDelete(deleteBehavior: DeleteBehavior.ClientCascade);

            builder
                .HasOne(x => x.Subcategoria)
                .WithMany()
                .OnDelete(deleteBehavior: DeleteBehavior.ClientCascade);

            builder.ToTable("AAServicos");
        }
    }

}