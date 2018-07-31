using Microsoft.AspNetCore.Identity;
using ServicoOnlineServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoOnlineServer.usuario.entidade
{
    public class Usuario: IdentityUser
    {
        public EmpresaUsuarioFuncaoViewModel EmpresaUsuario { get; set; }

        public IdentityUser toIdentityUser()
        {
            IdentityUser identityUser = new IdentityUser();
            identityUser.AccessFailedCount = this.AccessFailedCount;
            identityUser.ConcurrencyStamp = this.ConcurrencyStamp;
            identityUser.Email = this.Email;
            identityUser.EmailConfirmed = this.EmailConfirmed;
            identityUser.Id = this.Id;
            identityUser.LockoutEnabled = this.LockoutEnabled;
            identityUser.LockoutEnd = this.LockoutEnd;
            identityUser.NormalizedEmail = this.NormalizedEmail;
            identityUser.NormalizedUserName = this.NormalizedUserName;
            identityUser.PasswordHash = this.PasswordHash;
            identityUser.PhoneNumber = this.PhoneNumber;
            identityUser.PhoneNumberConfirmed = this.PhoneNumberConfirmed;
            identityUser.SecurityStamp = this.SecurityStamp;
            identityUser.TwoFactorEnabled = this.TwoFactorEnabled;
            identityUser.UserName = this.UserName;
            return identityUser;
        }
    }
}
