using Microsoft.EntityFrameworkCore;
using ServicoOnlineBusiness.bases.contexto;
using ServicoOnlineBusiness.bases.repositorio;
using ServicoOnlineBusiness.pagamento.dominio.entidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ServicoOnlineBusiness.pagamento.repositorio
{
    internal class PagamentoRepositorio : RepositorioBase<PagamentoDominio>
    {
        internal PagamentoRepositorio(DbContextOptions<ServicoContexto> options, IsolationLevel isolationLevel) : base(isolationLevel)
        {
            this.Contexto = ServicoContexto.Create(options);
            this.configurarContextoPerformance();
        }

        internal static PagamentoRepositorio Create(DbContextOptions<ServicoContexto> options, IsolationLevel isolationLevel)
        {
            return new PagamentoRepositorio(options, isolationLevel);
        }

        public PagamentoRepositorio Set(Func<PagamentoDominio, bool> predicate)
        {
            this.Queryable = this.Contexto.Set<PagamentoDominio>().Where(predicate).AsQueryable();
            return this;
        }
        public PagamentoRepositorio Set(IQueryable<PagamentoDominio> query)
        {
            this.Queryable = query;
            return this;
        }
        public PagamentoRepositorio SetAll()
        {
            this.Queryable = this.Contexto.Set<PagamentoDominio>();
            return this;
        }

        public IQueryable<PagamentoDominio> Get()
        {
            return this.Queryable.AsNoTracking();
        }
    }
}
