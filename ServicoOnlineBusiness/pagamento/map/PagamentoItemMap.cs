using Microsoft.EntityFrameworkCore;
using ServicoOnlineBusiness.pagamento.dominio.entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineBusiness.pagamento.map
{
    internal class PagamentoItemMap
    {
        private PagamentoItemMap(ModelBuilder builder)
        {

            builder.Entity<PagamentoItemDominio>().ToTable("PagamentoItem", "dbo");
            builder.Entity<PagamentoItemDominio>().HasKey(x => x.Id);
            builder.Entity<PagamentoItemDominio>().Property(x => x.Id).HasDefaultValue(Guid.NewGuid());
            builder.Entity<PagamentoItemDominio>().Property(x => x.Quantidade).IsRequired();
            builder.Entity<PagamentoItemDominio>().Property(x => x.ServicoDominioId).IsRequired();
            builder.Entity<PagamentoItemDominio>().Property(x => x.PagamentoDominioId).IsRequired();
            builder.Entity<PagamentoItemDominio>().Property(x => x.Status).HasMaxLength(2).HasDefaultValue("AT");
        }

        internal static PagamentoItemMap createInstance(ModelBuilder builder)
        {
            return new PagamentoItemMap(builder);
        }
    }
}
