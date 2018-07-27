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
    internal class FuncaoRequisicaoServices : ServicesStrategy<IdentityRoleClaim<string>>
    {
        private IdentityRoleClaim<string> _funcaoRequisicao = null;
        private DbContextOptionsBuilder<UsuarioContexto> optionsBuilder;
        private UsuarioContexto usuarioContexto = null;
        protected IsolationLevel isolationLevel;
        private FuncaoRequisicaoServices(ISqlBase sqlBase, IsolationLevel isolationLevel)
        {
            this.isolationLevel = isolationLevel;
            this.optionsBuilder = new DbContextOptionsBuilder<UsuarioContexto>();
            this.optionsBuilder.UseSqlServer(sqlBase.getConnection());
            this.usuarioContexto = new UsuarioContexto(optionsBuilder.Options);
        }
        internal static FuncaoRequisicaoServices Create(ISqlBase sqlBase, IsolationLevel isolationLevel)
        {
            return new FuncaoRequisicaoServices(sqlBase, isolationLevel);
        }
        internal override Task<string> createHashCodigo()
        {
            throw new NotImplementedException();
        }

        internal override IList<IdentityRoleClaim<string>> Gets(int paginaIndex, string filtro, int registroPorPagina)
        {
            throw new NotImplementedException();
        }

        internal override Task<IList<IdentityRoleClaim<string>>> GetsAsync(int paginaIndex, string filtro, int registroPorPagina)
        {
            throw new NotImplementedException();
        }

        internal override int getTotalDeRegistros()
        {
            throw new NotImplementedException();
        }

        internal override IdentityRoleClaim<string> Incluir(IdentityRoleClaim<string> entidade)
        {
            throw new NotImplementedException();
        }

        internal async override Task<IdentityRoleClaim<string>> IncluirAsync(IdentityRoleClaim<string> entidade)
        {
            try
            {
                this.usuarioContexto.Database.BeginTransaction(this.isolationLevel);

                this.usuarioContexto.RoleClaims.Add(entidade);

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
