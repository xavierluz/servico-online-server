using Microsoft.EntityFrameworkCore;
using ServicoOnlineBusiness.servico.dominio.entidade;
using ServicoOnlineBusiness.servico.map;
using ServicoOnlineBusiness.tiposervico.dominio.entidade;
using ServicoOnlineBusiness.tiposervico.map;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineBusiness.bases.contexto
{
    public class ServicoContexto : DbContext
    {
        internal virtual DbSet<TipoServicoDominio> TipoServicos { get; set; }
        internal virtual DbSet<ServicoDominio> Servicos { get; set; }
        private ServicoContexto(DbContextOptions<ServicoContexto> options) : base(options)
        {

        }

        internal static ServicoContexto Create(DbContextOptions<ServicoContexto> options)
        {
            return new ServicoContexto(options);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            TipoServicoMap.createInstance(builder);
            ServicoMap.createInstance(builder);
            builder.HasDefaultSchema("db");
            base.OnModelCreating(builder);
        }
    }
}
