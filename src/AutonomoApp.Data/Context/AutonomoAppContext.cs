using AutonomoApp.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;

namespace AutonomoApp.Data.Context;

public class AutonomoAppContext : DbContext

{

    #region DbSet<>
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Subcategoria> Subcategorias { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Pessoa> Pessoa { get; set; }
    public DbSet<PessoaFisica> PessoaFisica { get; set; }
    public DbSet<PessoaJuridica> PessoaJuridica { get; set; }
    public DbSet<ServicoSolicitado> ServicoSolicitado { get; set; }
    public DbSet<Servico> Servico { get; set; }
    public DbSet<ServicoCategoria> ServicoCategoria { get; set; }
    public DbSet<ServicoSubCategoria> ServicoSubCategoria { get; set; }
    public DbSet<Conta> Conta { get; set; }
    public DbSet<Beneficio> Beneficios { get; set; }

    #endregion

    public AutonomoAppContext()
    {

    }

    public AutonomoAppContext(DbContextOptions<AutonomoAppContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
        //Database.EnsureCreated();
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            //.AddJsonFile("appsettings.json", true, true)
            //.AddJsonFile($"appsettings.{environmentName}.json", true, true)
            .AddEnvironmentVariables()
            .AddUserSecrets<AutonomoAppContext>()
            .Build();

        var cnn = config.GetConnectionString($"{environmentName}");

        // const string strConnection = "";

        optionsBuilder
            .UseSqlServer(cnn)
            .EnableSensitiveDataLogging()
            //.UseLazyLoadingProxies()
            .LogTo(Console.WriteLine, LogLevel.Error);
            //.LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted }, LogLevel.Information, DbContextLoggerOptions.LocalTime | DbContextLoggerOptions.SingleLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");

        foreach (var property in modelBuilder.Model.GetEntityTypes()
                     .SelectMany((e) => e.GetProperties()
                         .Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AutonomoAppContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}