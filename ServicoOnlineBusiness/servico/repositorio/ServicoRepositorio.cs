using Microsoft.EntityFrameworkCore;
using ServicoOnlineBusiness.bases.contexto;
using ServicoOnlineBusiness.bases.repositorio;
using ServicoOnlineBusiness.servico.dominio.entidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ServicoOnlineBusiness.servico.repositorio
{
    internal class ServicoRepositorio : RepositorioBase<ServicoDominio>
    {
        internal ServicoRepositorio(DbContextOptions<ServicoContexto> options, IsolationLevel isolationLevel) : base(isolationLevel)
        {
            this.Contexto = ServicoContexto.Create(options);
        }

        internal static ServicoRepositorio Create(DbContextOptions<ServicoContexto> options, IsolationLevel isolationLevel)
        {
            return new ServicoRepositorio(options, isolationLevel);
        }

        public ServicoRepositorio Set(Func<ServicoDominio, bool> predicate)
        {
            this.Queryable = this.Contexto.Set<ServicoDominio>().Where(predicate).AsQueryable();
            return this;
        }
        public ServicoRepositorio Set(IQueryable<ServicoDominio> query)
        {
            this.Queryable = query;
            return this;
        }
        public ServicoRepositorio SetAll()
        {
            this.Queryable = this.Contexto.Set<ServicoDominio>();
            return this;
        }

        public IQueryable<ServicoDominio> Get()
        {
            return this.Queryable.AsNoTracking();
        }
    }
}
