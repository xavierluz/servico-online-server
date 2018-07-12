using Microsoft.AspNetCore.Identity;
using ServicoOnlineUsuario.empresa.dominio.entidade;
using ServicoOnlineUsuario.empresa.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ServicoOnlineUsuario.usuario.dominio.entidade
{
    [NotMapped]
    internal class Usuario : IdentityUser
    {
        private Usuario() { }
        internal static Usuario Create()
        {
            return new Usuario();
        }
        internal IEmpresa IEmpresa { get; set; }
        internal Guid EmpresaId { get; set; }
    }
}
