using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoOnlineServer.ViewModels
{
    public class UsuarioLoginViewModel
    {
        public EmpresaUsuarioFuncaoViewModel EmpresaUsuario { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public UserLoginInfo toUserLoginInfo()
        {
            UserLoginInfo userLoginInfo = new UserLoginInfo(this.LoginProvider, this.ProviderKey, this.ProviderDisplayName);
            return userLoginInfo;
        }
    }
}
