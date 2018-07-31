using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServicoOnlineUsuario.bases;
using ServicoOnlineUsuario.bases.banco.interfaces;
using ServicoOnlineUsuario.usuario.contexto;
using ServicoOnlineUsuario.usuario.dominio.entidade;
using ServicoOnlineUsuario.usuario.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ServicoOnlineUsuario.usuario
{
    public class UsuarioServices : ServicesStrategy<IdentityUser>
    {
        private IUsuario _Usuario = null;
        private DbContextOptionsBuilder<UsuarioContexto> optionsBuilder;
        private UsuarioContexto usuarioContexto = null;

        protected IsolationLevel isolationLevel;

        private UsuarioServices(ISqlBase sqlBase, IsolationLevel isolationLevel) {
            this.isolationLevel = isolationLevel;
            this.optionsBuilder = new DbContextOptionsBuilder<UsuarioContexto>();
            this.optionsBuilder.UseSqlServer(sqlBase.getConnection());
            this.usuarioContexto = new UsuarioContexto(optionsBuilder.Options);
        }
        internal static UsuarioServices Create(ISqlBase sqlBase, IsolationLevel isolationLevel)
        {
            return new UsuarioServices(sqlBase, isolationLevel);
        }

        internal override Task<string> createHashCodigo(String valorParaCriptografar)
        {
            throw new NotImplementedException();
        }

        internal override IList<IdentityUser> Gets(int paginaIndex, string filtro, int registroPorPagina)
        {
            throw new NotImplementedException();
        }

        internal override Task<IList<IdentityUser>> GetsAsync(int paginaIndex, string filtro, int registroPorPagina)
        {
            throw new NotImplementedException();
        }

        internal override int getTotalDeRegistros()
        {
            throw new NotImplementedException();
        }

        internal override IdentityUser Incluir(IdentityUser entidade)
        {
            throw new NotImplementedException();
        }

        internal async override Task<IdentityUser> IncluirAsync(IdentityUser entidade)
        {
            try
            {
                this.usuarioContexto.Database.BeginTransaction(this.isolationLevel);

                this.usuarioContexto.Add(entidade);
                Task<int> registrosAfetados = this.usuarioContexto.SaveChangesAsync();
                if (registrosAfetados.Result > 0)
                    this.usuarioContexto.Database.CurrentTransaction.Commit();
                else
                    this.usuarioContexto.Database.CurrentTransaction.Rollback();

                await registrosAfetados;

                return entidade;
            }catch(Exception ex)
            {
                if (this.usuarioContexto.Database.CurrentTransaction != null)
                    this.usuarioContexto.Database.CurrentTransaction.Rollback();

                throw ex;
            }
        }
    }
}
