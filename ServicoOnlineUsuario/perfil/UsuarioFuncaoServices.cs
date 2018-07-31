using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServicoOnlineUsuario.bases;
using ServicoOnlineUsuario.bases.banco.interfaces;
using ServicoOnlineUsuario.usuario.contexto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ServicoOnlineUsuario.perfil
{
    public class UsuarioFuncaoServices : ServicesStrategy<IdentityUserRole<string>>
    {
        private IdentityRoleClaim<string> _funcaoRequisicao = null;
        private DbContextOptionsBuilder<UsuarioContexto> optionsBuilder;
        private UsuarioContexto usuarioContexto = null;
        protected IsolationLevel isolationLevel;
        private UsuarioFuncaoServices(ISqlBase sqlBase, IsolationLevel isolationLevel)
        {
            this.isolationLevel = isolationLevel;
            this.optionsBuilder = new DbContextOptionsBuilder<UsuarioContexto>();
            this.optionsBuilder.UseSqlServer(sqlBase.getConnection());
            this.usuarioContexto = new UsuarioContexto(optionsBuilder.Options);
        }
        internal static UsuarioFuncaoServices Create(ISqlBase sqlBase, IsolationLevel isolationLevel)
        {
            return new UsuarioFuncaoServices(sqlBase, isolationLevel);
        }

        internal override Task<string> createHashCodigo(String valorParaCriptografar)
        {
            throw new NotImplementedException();
        }

        internal override IList<IdentityUserRole<string>> Gets(int paginaIndex, string filtro, int registroPorPagina)
        {
            throw new NotImplementedException();
        }

        internal override Task<IList<IdentityUserRole<string>>> GetsAsync(int paginaIndex, string filtro, int registroPorPagina)
        {
            throw new NotImplementedException();
        }

        internal override int getTotalDeRegistros()
        {
            throw new NotImplementedException();
        }

        internal override IdentityUserRole<string> Incluir(IdentityUserRole<string> entidade)
        {
            throw new NotImplementedException();
        }

        internal async override Task<IdentityUserRole<string>> IncluirAsync(IdentityUserRole<string> entidade)
        {

            try
            {
                this.usuarioContexto.Database.BeginTransaction(this.isolationLevel);

                this.usuarioContexto.UserRoles.Add(entidade);

                Task<int> registrosAfetados = this.usuarioContexto.SaveChangesAsync();
                if (registrosAfetados.Result > 0)
                    this.usuarioContexto.Database.CurrentTransaction.Commit();
                else
                    this.usuarioContexto.Database.CurrentTransaction.Rollback();

                await registrosAfetados;

                return entidade;
            }
            catch (Exception ex)
            {
                if (this.usuarioContexto.Database.CurrentTransaction != null)
                    this.usuarioContexto.Database.CurrentTransaction.Rollback();

                throw ex;
            }
        }
    }
}
