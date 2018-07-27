using Microsoft.AspNetCore.Identity;
using ServicoOnlineServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServicoOnlineServer.perfil.funcao
{
    internal static class FuncaoConverter
    {
        internal static FuncaoRequisicaoTableViewModel converterIdentityRoleClaimParaClaim(IdentityRoleClaim<string> identityRoleClaim)
        {
            FuncaoRequisicaoTableViewModel funcaoRequisicaoTableViewModel = null;
            if(identityRoleClaim != null)
            {
                Claim claim = identityRoleClaim.ToClaim();

                funcaoRequisicaoTableViewModel = new FuncaoRequisicaoTableViewModel();
                funcaoRequisicaoTableViewModel.Id = identityRoleClaim.Id;
                funcaoRequisicaoTableViewModel.Type = claim.Type;
                funcaoRequisicaoTableViewModel.ValueType = claim.ValueType;
                funcaoRequisicaoTableViewModel.Value = claim.Value;
            }

            return funcaoRequisicaoTableViewModel;
        }
    }
}
