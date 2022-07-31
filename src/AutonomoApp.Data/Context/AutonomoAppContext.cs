using AutonomoApp.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

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
    public DbSet<ServicoSolicitacao> ServicoSolicitacao { get; set; }
    public DbSet<Servico> Servico { get; set; }
    public DbSet<ServicoCategoria> ServicoCategoria { get; set; }
    public DbSet<ServicoSubCategoria> ServicoSubCategoria { get; set; } 
    #endregion

    public AutonomoAppContext(DbContextOptions<AutonomoAppContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
        //Database.EnsureCreated();
    }

    public AutonomoAppContext()
    {
        
    }


    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    const string strConnection = "Server=ASUS-ROG\\SQLEXPRESS;Database=CURSOEF;User Id=sa; Password=$Oblivion95; MultipleActiveResultSets=true; pooling=true";
    //    optionsBuilder
    //        .UseSqlServer(strConnection)
    //        .EnableSensitiveDataLogging()
            
    //        //.UseLazyLoadingProxies()
    //        .LogTo(Console.WriteLine, LogLevel.Error);
    //    //.LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted }, LogLevel.Information, DbContextLoggerOptions.LocalTime | DbContextLoggerOptions.SingleLine);
    //}

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