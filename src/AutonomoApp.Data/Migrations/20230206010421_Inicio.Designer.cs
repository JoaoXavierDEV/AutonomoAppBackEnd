﻿// <auto-generated />
using System;
using AutonomoApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutonomoApp.Data.Migrations
{
    [DbContext(typeof(AutonomoAppContext))]
    [Migration("20230206010421_Inicio")]
    partial class Inicio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("SQL_Latin1_General_CP1_CS_AS")
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AutonomoApp.Business.Models.Beneficio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("ContaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("TipoDeBeneficio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContaId");

                    b.ToTable("AABeneficio", (string)null);
                });

            modelBuilder.Entity("AutonomoApp.Business.Models.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoriaEnum")
                        .HasColumnType("int")
                        .HasColumnName("EnumId");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("AACategorias", (string)null);
                });

            modelBuilder.Entity("AutonomoApp.Business.Models.Conta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<bool>("PlanoVitalicio")
                        .HasColumnType("bit");

                    b.Property<bool>("PremiumAtivo")
                        .HasColumnType("bit");

                    b.Property<bool>("RenovacaoAutomatica")
                        .HasColumnType("bit");

                    b.Property<bool>("UsuarioVerificado")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("AAConta", (string)null);
                });

            modelBuilder.Entity("AutonomoApp.Business.Models.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Cidade")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Estado")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("varchar(55)");

                    b.Property<string>("Numero")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("AAEnderecos", (string)null);
                });

            modelBuilder.Entity("AutonomoApp.Business.Models.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Documento")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("EnderecoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TipoDocumento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContaId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("AAPessoa", (string)null);
                });

            modelBuilder.Entity("AutonomoApp.Business.Models.Servico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AnuncioAtivo")
                        .HasColumnType("bit");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientePrestadorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataPublicada")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Desconto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("PermiteParcelamento")
                        .HasColumnType("bit");

                    b.Property<Guid>("SubcategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TemDesconto")
                        .HasColumnType("bit");

                    b.Property<int>("TipoDeServico")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ClientePrestadorId");

                    b.HasIndex("SubcategoriaId");

                    b.ToTable("AAServicos", (string)null);
                });

            modelBuilder.Entity("AutonomoApp.Business.Models.ServicoSolicitado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClienteSolicitanteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataConclusao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataConclusaoEstimada")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ServicoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClienteSolicitanteId");

                    b.HasIndex("ServicoId");

                    b.ToTable("AAHistoricoDePedidos", (string)null);
                });

            modelBuilder.Entity("AutonomoApp.Business.Models.Subcategoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("SubCategoriaEnum")
                        .HasColumnType("int")
                        .HasColumnName("EnumId");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("AASubCategorias", (string)null);
                });

            modelBuilder.Entity("AutonomoApp.Business.Models.PessoaFisica", b =>
                {
                    b.HasBaseType("AutonomoApp.Business.Models.Pessoa");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("datetime2");

                    b.ToTable("AAPessoaFisica", (string)null);
                });

            modelBuilder.Entity("AutonomoApp.Business.Models.PessoaJuridica", b =>
                {
                    b.HasBaseType("AutonomoApp.Business.Models.Pessoa");

                    b.Property<string>("NomeEmpresa")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.ToTable("AAPessoaJuridica", (string)null);
                });

            modelBuilder.Entity("AutonomoApp.Business.Models.Beneficio", b =>
                {
                    b.HasOne("AutonomoApp.Business.Models.Conta", null)
                        .WithMany("Benefícios")
                        .HasForeignKey("ContaId");
                });

            modelBuilder.Entity("AutonomoApp.Business.Models.Pessoa", b =>
                {
                    b.HasOne("AutonomoApp.Business.Models.Conta", "Conta")
                        .WithMany()
                        .HasForeignKey("ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutonomoApp.Business.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.Navigation("Conta");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("AutonomoApp.Business.Models.Servico", b =>
                {
                    b.HasOne("AutonomoApp.Business.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("AutonomoApp.Business.Models.Pessoa", "ClientePrestador")
                        .WithMany()
                        .HasForeignKey("ClientePrestadorId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("AutonomoApp.Business.Models.Subcategoria", "Subcategoria")
                        .WithMany()
                        .HasForeignKey("SubcategoriaId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("ClientePrestador");

                    b.Navigation("Subcategoria");
                });

            modelBuilder.Entity("AutonomoApp.Business.Models.ServicoSolicitado", b =>
                {
                    b.HasOne("AutonomoApp.Business.Models.Pessoa", "ClienteSolicitante")
                        .WithMany("HistoricoDePedidos")
                        .HasForeignKey("ClienteSolicitanteId");

                    b.HasOne("AutonomoApp.Business.Models.Servico", "Servico")
                        .WithMany()
                        .HasForeignKey("ServicoId");

                    b.Navigation("ClienteSolicitante");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("AutonomoApp.Business.Models.Subcategoria", b =>
                {
                    b.HasOne("AutonomoApp.Business.Models.Categoria", null)
                        .WithMany("Subcategorias")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("AutonomoApp.Business.Models.PessoaFisica", b =>
                {
                    b.HasOne("AutonomoApp.Business.Models.Pessoa", null)
                        .WithOne()
                        .HasForeignKey("AutonomoApp.Business.Models.PessoaFisica", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutonomoApp.Business.Models.PessoaJuridica", b =>
                {
                    b.HasOne("AutonomoApp.Business.Models.Pessoa", null)
                        .WithOne()
                        .HasForeignKey("AutonomoApp.Business.Models.PessoaJuridica", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutonomoApp.Business.Models.Categoria", b =>
                {
                    b.Navigation("Subcategorias");
                });

            modelBuilder.Entity("AutonomoApp.Business.Models.Conta", b =>
                {
                    b.Navigation("Benefícios");
                });

            modelBuilder.Entity("AutonomoApp.Business.Models.Pessoa", b =>
                {
                    b.Navigation("HistoricoDePedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
