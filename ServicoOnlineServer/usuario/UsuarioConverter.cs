using Microsoft.AspNetCore.Identity;
using ServicoOnlineServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServicoOnlineServer.usuario
{
    internal class UsuarioConverter
    {
        internal static UsuarioTableViewModel converterIdentityUserParaUsuarioTableViewModel(IdentityUser identityUser)
        {
            UsuarioTableViewModel usuarioTableViewModel = null;
            if (identityUser != null)
            {
                usuarioTableViewModel = new UsuarioTableViewModel();

                usuarioTableViewModel.Email = identityUser.Email;
                usuarioTableViewModel.Id = identityUser.Id;
                usuarioTableViewModel.PhoneNumber = identityUser.PhoneNumber;
                usuarioTableViewModel.TwoFactorEnabled = (identityUser.TwoFactorEnabled == false ? "Não" : "Sim");
                usuarioTableViewModel.UserName = identityUser.UserName;
            }

            return usuarioTableViewModel;
        }
        internal static RequisicaoTableViewModel converterIdentityUserClaimParaClaim(IdentityUserClaim<string> identityUserClaim)
        {
            RequisicaoTableViewModel funcaoRequisicaoTableViewModel = null;
            if (identityUserClaim != null)
            {
                Claim claim = identityUserClaim.ToClaim();

                funcaoRequisicaoTableViewModel = new RequisicaoTableViewModel();
                funcaoRequisicaoTableViewModel.Id = identityUserClaim.Id;
                funcaoRequisicaoTableViewModel.Type = claim.Type;
                funcaoRequisicaoTableViewModel.ValueType = claim.ValueType;
                funcaoRequisicaoTableViewModel.Value = claim.Value;
            }

            return funcaoRequisicaoTableViewModel;
        }
    }
}
