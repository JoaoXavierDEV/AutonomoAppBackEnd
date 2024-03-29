﻿using AutonomoApp.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutonomoApp.Data.Mappings;

public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasMany(x => x.HistoricoDePedidos);

        builder.HasOne(x => x.Conta);

        builder.ToTable("Pessoa");
    }
}
public class PessoaFisicaMapping : IEntityTypeConfiguration<PessoaFisica>
{
    public void Configure(EntityTypeBuilder<PessoaFisica> builder)
    {
        builder.ToTable("PessoaFisica");
    }
}
public class PessoaJuridicaMapping : IEntityTypeConfiguration<PessoaJuridica>
{
    public void Configure(EntityTypeBuilder<PessoaJuridica> builder)
    {
        builder.ToTable("PessoaJuridica");
    }
}