using AutonomoApp.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomoApp.Data.Mappings;

public class ContaMapping : IEntityTypeConfiguration<Conta>
{
    public void Configure(EntityTypeBuilder<Conta> builder)
    {
        builder.HasKey(x => x.Id);


      //  var splitStringConverter1 = new ValueConverter<IEnumerable<string>, string>(
      //v => string.Join(",", v.Where(x => !string.IsNullOrWhiteSpace(x)).ToList()),
      //v => v.Replace(" ", string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries).Where(x => x != "").ToList());

      //  var splitStringConverter = new ValueConverter<IEnumerable<string>, string>(
      //      v => string.Join(",", v),
      //      v => v.Split(",", StringSplitOptions.RemoveEmptyEntries));

      //  var splitStringConverter3 = new ValueConverter<IEnumerable<string>, string>(
      //      v => string.Join(",", v),
      //      v => v.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList());

        builder.HasMany(p => p.Benefícios);

       // builder.ToTable("AAConta");
    }
}
