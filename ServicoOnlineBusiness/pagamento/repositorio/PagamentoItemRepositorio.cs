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
    internal class PagamentoItemRepositorio : RepositorioBase<PagamentoItemDominio>
    {
        internal PagamentoItemRepositorio(DbContextOptions<ServicoContexto> options, IsolationLevel isolationLevel) : base(isolationLevel)
        {
            this.Contexto = ServicoContexto.Create(options);
            this.configurarContextoPerformance();
        }

        internal static PagamentoItemRepositorio Create(DbContextOptions<ServicoContexto> options, IsolationLevel isolationLevel)
        {
            return new PagamentoItemRepositorio(options, isolationLevel);
        }

        public PagamentoItemRepositorio Set(Func<PagamentoItemDominio, bool> predicate)
        {
            this.Queryable = this.Contexto.Set<PagamentoItemDominio>().Where(predicate).AsQueryable();
            return this;
        }
        public PagamentoItemRepositorio Set(IQueryable<PagamentoItemDominio> query)
        {
            this.Queryable = query;
            return this;
        }
        public PagamentoItemRepositorio SetAll()
        {
            this.Queryable = this.Contexto.Set<PagamentoItemDominio>();
            return this;
        }

        public IQueryable<PagamentoItemDominio> Get()
        {
            return this.Queryable.AsNoTracking();
        }
    }
}
