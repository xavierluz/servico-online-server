using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using ServicoOnlineBusiness.tiposervico.dominio.entidade;
using ServicoOnlineBusiness.tiposervico.map;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineBusiness.tiposervico.contexto
{
    public class TipoServicoDbContexto : DbContext
    {
        internal virtual DbSet<TipoServicoDominio> TipoServicos { get; set; }

        private TipoServicoDbContexto(DbContextOptions<TipoServicoDbContexto> options) : base(options)
        {

        }

        internal static TipoServicoDbContexto Create(DbContextOptions<TipoServicoDbContexto> options)
        {
            return new TipoServicoDbContexto(options);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            TipoServicoMap.createInstance(builder);

            builder.HasDefaultSchema("db");
            base.OnModelCreating(builder);
        }
    }
}
