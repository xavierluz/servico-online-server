using Microsoft.AspNetCore.Mvc;
using ServicoOnlineServer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoOnlineServer.extensao
{
    public static class UrlHelperExtensao
    {
        public static string EmailConfirmarLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(UsuarioController.ConfirmarEmail),
                controller: "Usuario",
                values: new { userId, code },
                protocol: scheme);
        }

        public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(UsuarioController.ResetSenha),
                controller: "Usuario",
                values: new { userId, code },
                protocol: scheme);
        }
    }
}
