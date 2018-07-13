using Microsoft.EntityFrameworkCore;
using ServicoOnlineUsuario.bases;
using ServicoOnlineUsuario.empresa.contexto;
using ServicoOnlineUsuario.empresa.dominio.entidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ServicoOnlineUsuario.empresa.repositorio
{
    internal class EmpresaRepositorio : RepositorioBase<Empresa>
    {
        private EmpresaRepositorio(DbContextOptions<EmpresaContexto> options, IsolationLevel isolationLevel) : base(isolationLevel)
        {
            this.Contexto = EmpresaContexto.Create(options);
            this.configurarContextoPerformance();
        }

        internal static EmpresaRepositorio Create(DbContextOptions<EmpresaContexto> options, IsolationLevel isolationLevel)
        {
            return new EmpresaRepositorio(options, isolationLevel);
        }

        public EmpresaRepositorio Set(Func<Empresa, bool> predicate)
        {
            this.Queryable = this.Contexto.Set<Empresa>().Where(predicate).AsQueryable();
            return this;
        }
        public EmpresaRepositorio Set(IQueryable<Empresa> query)
        {
            this.Queryable = query;
            return this;
        }
        public EmpresaRepositorio SetAll()
        {
            this.Queryable = this.Contexto.Set<Empresa>();
            return this;
        }

        public IQueryable<Empresa> Get()
        {
            return this.Queryable.AsNoTracking();
        }
    }
}
