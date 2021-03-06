﻿using Microsoft.EntityFrameworkCore;
using ServicoOnlineBusiness.pagamento.dominio.entidade;
using ServicoOnlineBusiness.pagamento.map;
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
        internal virtual DbSet<PagamentoDominio> PagamentoDominios { get; set; }
        internal virtual DbSet<PagamentoItemDominio> PagamentoItemDominios { get; set; }
        private ServicoContexto(DbContextOptions<ServicoContexto> options) : base(options)
        {

        }

        internal static ServicoContexto Create(DbContextOptions<ServicoContexto> options)
        {
            return new ServicoContexto(options);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            TipoServicoMap.createInstance(builder);
            ServicoMap.createInstance(builder);
            PagamentoMap.createInstance(builder);
            PagamentoItemMap.createInstance(builder);

            builder.HasDefaultSchema("dbo");
            RelacionamentoServico.Create(builder);
            
        }
    }
}
