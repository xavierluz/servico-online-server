using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServicoOnlineBusiness.bases.banco.interfaces;
using ServicoOnlineUsuario.usuario.contexto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoOnlineServer.usuario
{
    internal class GerenciarUsuario
    {

        private UserManager<IdentityUser> userManager = null;
        private DbContextOptionsBuilder<UsuarioContexto> _optionsBuilder = null;
        private UsuarioContexto _usuarioContexto = null;
        private ISqlBase _sqlBase;
        private IsolationLevel _isolationLevel;

        internal int totalRegistro { get; private set; }

        private GerenciarUsuario(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        private GerenciarUsuario(ISqlBase sqlBase, IsolationLevel isolationLevel)
        {
            this._isolationLevel = isolationLevel;
            this._sqlBase = sqlBase;
            this._optionsBuilder = new DbContextOptionsBuilder<UsuarioContexto>();
            this._optionsBuilder.UseSqlServer(sqlBase.getConnection());
        }
        internal static GerenciarUsuario Create(UserManager<IdentityUser> userManager)
        {
            return new GerenciarUsuario(userManager);
        }
        internal static GerenciarUsuario Create(ISqlBase sqlBase, IsolationLevel isolationLevel)
        {
            return new GerenciarUsuario(sqlBase, isolationLevel);
        }

        internal async Task<IList<IdentityUser>> Gets(int paginaIndex, string filtro, int registroPorPagina,string empresaId)
        {
            IQueryable<IdentityUser> usuarios = null;
            if (paginaIndex < 0)
                paginaIndex = 0;
            if (!string.IsNullOrEmpty(filtro) &&
                   !string.IsNullOrWhiteSpace(filtro))
            {

                usuarios = this.userManager.Users.Where(x => x.Id != String.Empty && (x.Email.ToUpper().Contains(filtro.ToUpper())
                                                || x.UserName.ToUpper().Contains(filtro.ToUpper())
                                                || x.PhoneNumber.ToString().ToUpper().Contains(filtro.ToUpper())
                                                || x.TwoFactorEnabled.ToString().ToUpper().Contains(filtro.ToUpper()))).AsNoTracking();
                this.totalRegistro = await usuarios.CountAsync();
                usuarios = null;

                usuarios = this.userManager.Users.Where(x => x.Id != String.Empty && (x.Email.ToUpper().Contains(filtro.ToUpper())
                                                || x.UserName.ToUpper().Contains(filtro.ToUpper())
                                                || x.PhoneNumber.ToString().ToUpper().Contains(filtro.ToUpper())
                                                || x.TwoFactorEnabled.ToString().ToUpper().Contains(filtro.ToUpper())))
                                                .Skip(paginaIndex).Take(registroPorPagina).AsNoTracking();
            }
            else
            {
                usuarios = this.userManager.Users.AsNoTracking();
                this.totalRegistro = await usuarios.CountAsync();
                usuarios = null;

                usuarios = this.userManager.Users.Skip(paginaIndex).Take(registroPorPagina).AsNoTracking();
            }

            return await usuarios.ToListAsync();
        }
    }
}
