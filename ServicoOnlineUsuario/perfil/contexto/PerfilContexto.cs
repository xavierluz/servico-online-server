using Microsoft.EntityFrameworkCore;
using ServicoOnlineUsuario.usuario.contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineUsuario.perfil.contexto
{
    internal class PerfilContexto : UsuarioContexto
    {
        internal PerfilContexto(DbContextOptions<UsuarioContexto> options) : base(options)
        {
        }

    }
}
