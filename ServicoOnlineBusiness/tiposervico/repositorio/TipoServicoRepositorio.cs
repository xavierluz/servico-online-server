using Microsoft.EntityFrameworkCore;
using ServicoOnlineBusiness.bases.repositorio;
using ServicoOnlineBusiness.tiposervico.contexto;
using ServicoOnlineBusiness.tiposervico.dominio.entidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ServicoOnlineBusiness.tiposervico.repositorio
{
    internal class TipoServicoRepositorio : RepositorioBase<TipoServicoDominio>
    {
        internal TipoServicoRepositorio(DbContextOptions<TipoServicoDbContexto> options,IsolationLevel isolationLevel) : base(isolationLevel)
        {
            this.Contexto = TipoServicoDbContexto.Create(options);
        }

        internal static TipoServicoRepositorio Create(DbContextOptions<TipoServicoDbContexto> options, IsolationLevel isolationLevel)
        {
            return new TipoServicoRepositorio(options, isolationLevel);
        }

        public TipoServicoRepositorio Set(Func<TipoServicoDominio, bool> predicate)
        {
            this.Queryable = this.Contexto.Set<TipoServicoDominio>().Where(predicate).AsQueryable();
            return this;
        }
        public TipoServicoRepositorio Set(IQueryable<TipoServicoDominio> query)
        {
            this.Queryable = query;
            return this;
        }
        public TipoServicoRepositorio SetAll()
        {
            this.Queryable = this.Contexto.Set<TipoServicoDominio>();
            return this;
        }

        public IQueryable<TipoServicoDominio> Get()
        {
            return this.Queryable.AsNoTracking();
        }
    }
}
