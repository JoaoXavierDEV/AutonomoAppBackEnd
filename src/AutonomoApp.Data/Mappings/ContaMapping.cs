using AutonomoApp.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

        builder.ToTable("AAConta");
    }
}
