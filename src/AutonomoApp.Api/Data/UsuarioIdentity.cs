using AutonomoApp.Business.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutonomoApp.WebApi.Data
{
    public class UsuarioIdentity : IdentityUser<Guid>
    {
        //private readonly ApplicationDbContext _context;
        [PersonalData]
        public Conta Conta { get; set; }

        public UsuarioIdentity()
        {
        }

        //public UsuarioIdentity(ApplicationDbContext context)
        //    : base(context)
        //{
        //    _context = context;
        //}

        //// Implemente os métodos necessários para associar a tabela personalizada
        //// Por exemplo, você pode sobrescrever o método UpdateAsync para salvar os dados personalizados na tabela
        //public override Task<IdentityResult> UpdateAsync(IdentityUser user, CancellationToken cancellationToken = default)
        //{
        //    // Atualize os dados personalizados na tabela
        //    // Utilize a chave estrangeira UserId para associar os dados à conta do Identity

        //    return base.UpdateAsync(user, cancellationToken);
        //}

    }
}
