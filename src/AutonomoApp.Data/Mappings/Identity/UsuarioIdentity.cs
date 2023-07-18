using AutonomoApp.Business.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutonomoApp.Data.Mappings.Identity
{
    public class UsuarioIdentity : IdentityUser<Guid>
    {
        [PersonalData]
        public Pessoa Pessoa { get; set; }

        public UsuarioIdentity()
        {
        }
    }
    public class UsuarioIdentityRole : IdentityRole<Guid>
    {

    }
}
