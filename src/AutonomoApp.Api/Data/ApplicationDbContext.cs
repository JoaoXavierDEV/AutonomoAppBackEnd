using AutonomoApp.Business.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AutonomoApp.WebApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<UsuarioIdentity, IdentityRole<Guid>, Guid>
    {
        public DbSet<UsuarioIdentity> UsuarioIdentity { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsuarioIdentity>()
                //.HasOne<Conta>(ud => ud.Id)
                .HasOne(ud => ud.Conta)
                ;
            //.HasForeignKey(ud => ud.Conta.Id);

            modelBuilder.Entity<UsuarioIdentity>().ToTable("AAUsuarioIdentity");
           
        }
    }
}
