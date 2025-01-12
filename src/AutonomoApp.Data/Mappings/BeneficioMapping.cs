using AutonomoApp.Framework;
using AutonomoApp.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomoApp.Data.Mappings
{
    public class BeneficioMapping : IEntityTypeConfiguration<Beneficio>

    {
        public void Configure(EntityTypeBuilder<Beneficio> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.TipoDeBeneficio)
                .HasConversion<string>();

            //builder.ToTable("AABeneficio");
        }
    }
}
