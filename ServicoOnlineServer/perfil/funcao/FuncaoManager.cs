using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServicoOnlineUsuario.bases.banco.interfaces;
using ServicoOnlineUsuario.usuario.contexto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServicoOnlineServer.perfil.funcao
{
    internal class FuncaoManager
    {
        private RoleManager<IdentityRole> _roleManager = null;
        private DbContextOptionsBuilder<UsuarioContexto> _optionsBuilder = null;
        private UsuarioContexto _usuarioContexto = null;
        private ISqlBase _sqlBase;
        private IsolationLevel _isolationLevel;

        internal int totalRegistro { get; private set; }

        private FuncaoManager(RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
        }
        private FuncaoManager(ISqlBase sqlBase, IsolationLevel isolationLevel)
        {
            this._isolationLevel = isolationLevel;
            this._sqlBase = sqlBase;
            this._optionsBuilder = new DbContextOptionsBuilder<UsuarioContexto>();
            this._optionsBuilder.UseSqlServer(sqlBase.getConnection());
        }
        internal static FuncaoManager Create(RoleManager<IdentityRole> roleManager)
        {
            return new FuncaoManager(roleManager);
        }
        internal static FuncaoManager Create(ISqlBase sqlBase, IsolationLevel isolationLevel)
        {
            return new FuncaoManager(sqlBase, isolationLevel);
        }
        internal async Task<IList<IdentityRole>> Gets(int paginaIndex, string filtro, int registroPorPagina)
        {
            IQueryable<IdentityRole> funcoes = null;
            if (paginaIndex < 0)
                paginaIndex = 0;
            if (!string.IsNullOrEmpty(filtro) &&
                   !string.IsNullOrWhiteSpace(filtro))
            {

                funcoes = this._roleManager.Roles.Where(x => x.Id != String.Empty && ( x.ConcurrencyStamp.ToUpper().Contains(filtro.ToUpper())
                                                || x.Name.ToUpper().Contains(filtro.ToUpper())
                                                || x.NormalizedName.ToUpper().Contains(filtro.ToUpper()))).AsNoTracking();
                this.totalRegistro = await funcoes.CountAsync();
                funcoes = null;

                funcoes = this._roleManager.Roles.Where(x => x.Id != String.Empty && (x.ConcurrencyStamp.ToUpper().Contains(filtro.ToUpper())
                                                || x.Name.ToUpper().Contains(filtro.ToUpper())
                                                || x.NormalizedName.ToUpper().Contains(filtro.ToUpper())))
                                        .Skip(paginaIndex).Take(registroPorPagina).AsNoTracking();
            }
            else
            {
                funcoes = this._roleManager.Roles.AsNoTracking();
                this.totalRegistro = await funcoes.CountAsync();
                funcoes = null;

                funcoes = this._roleManager.Roles.Skip(paginaIndex).Take(registroPorPagina).AsNoTracking();
            }

            return await funcoes.ToListAsync();
        }
        internal async Task<List<IdentityRoleClaim<string>>> getsRequisicoes(string funcaoId, int paginaIndex, string filtro, int registroPorPagina)
        {

            this._usuarioContexto = new UsuarioContexto(_optionsBuilder.Options);
            IQueryable<IdentityRoleClaim<string>> requisicoes = null;
            if (paginaIndex < 0)
                paginaIndex = 0;
            if (!string.IsNullOrEmpty(filtro) &&
                   !string.IsNullOrWhiteSpace(filtro))
            {

                requisicoes = (from q in this._usuarioContexto.RoleClaims
                           where q.RoleId == funcaoId
                              && (q.ClaimType.ToUpper().Contains(filtro.ToUpper()) || q.ClaimValue.ToUpper().Contains(filtro.ToUpper()))
                           select q).AsNoTracking();
                this.totalRegistro = await requisicoes.CountAsync();
                requisicoes = null;

                requisicoes = (from q in this._usuarioContexto.RoleClaims
                               where q.RoleId == funcaoId
                                  && (q.ClaimType.ToUpper().Contains(filtro.ToUpper()) || q.ClaimValue.ToUpper().Contains(filtro.ToUpper()))
                               select q).Skip(paginaIndex).Take(registroPorPagina).AsNoTracking();
            }
            else
            {
                requisicoes = (from q in this._usuarioContexto.RoleClaims
                               where q.RoleId == funcaoId
                               select q).AsNoTracking();

                this.totalRegistro = await requisicoes.CountAsync();
                requisicoes = null;

                requisicoes = (from q in this._usuarioContexto.RoleClaims
                               where q.RoleId == funcaoId
                               select q).Skip(paginaIndex).Take(registroPorPagina).AsNoTracking();
            }

            return await requisicoes.ToListAsync();
        }
    }
}
