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
    public class FuncaoServices : ServicesStrategy<IdentityRole>
    {
        private DbContextOptionsBuilder<UsuarioContexto> optionsBuilder;
        protected IsolationLevel isolationLevel;
        private UsuarioContexto contexto = null;
        private FuncaoServices(ISqlBase sqlBase, IsolationLevel isolationLevel) {
            this.isolationLevel = isolationLevel;
            this.optionsBuilder = new DbContextOptionsBuilder<UsuarioContexto>();
            this.optionsBuilder.UseSqlServer(sqlBase.getConnection());
        }
        internal static FuncaoServices Create(ISqlBase sqlBase, IsolationLevel isolationLevel)
        {
            return new FuncaoServices(sqlBase, isolationLevel);
        }
        internal async override Task<IdentityRole> IncluirAsync(IdentityRole entidade)
        {

            contexto = new UsuarioContexto(optionsBuilder.Options);
            contexto.Database.BeginTransaction(this.isolationLevel);
            contexto.Roles.Add(entidade);
            Task<int> registrosAfetados = contexto.SaveChangesAsync();

            if (registrosAfetados.Result > 0)
                contexto.Database.CurrentTransaction.Commit();
            else
                contexto.Database.CurrentTransaction.Rollback();
           
            await registrosAfetados;

            return entidade;
        }

        internal override Task<string> createHashCodigo()
        {
            throw new NotImplementedException();
        }

        internal override IdentityRole Incluir(IdentityRole entidade)
        {
            throw new NotImplementedException();
        }

        internal override Task<IList<IdentityRole>> GetsAsync(int paginaIndex, string filtro, int registroPorPagina)
        {
            throw new NotImplementedException();
        }

        internal override IList<IdentityRole> Gets(int paginaIndex, string filtro, int registroPorPagina)
        {
            throw new NotImplementedException();
        }

        internal override int getTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
