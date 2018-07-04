using Microsoft.EntityFrameworkCore;
using ServicoOnlineBusiness.pagamento.dominio.entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineBusiness.pagamento.map
{
    internal class PagamentoMap
    {
        private PagamentoMap(ModelBuilder builder)
        {

            builder.Entity<PagamentoDominio>().ToTable("Pagamento", "db");
            builder.Entity<PagamentoDominio>().HasKey(x => x.Id);
            builder.Entity<PagamentoDominio>().Property(x => x.Id).HasDefaultValue(Guid.NewGuid());
            builder.Entity<PagamentoDominio>().Property(x => x.Nome).HasMaxLength(50).IsRequired();
            builder.Entity<PagamentoDominio>().Property(x => x.Email).HasMaxLength(100);
            builder.Entity<PagamentoDominio>().Property(x => x.Descricao).HasMaxLength(1000);
            builder.Entity<PagamentoDominio>().Property(x => x.Telefone).HasMaxLength(12);
            builder.Entity<PagamentoDominio>().Property(x => x.Status).HasMaxLength(2).HasDefaultValue("AT");
            builder.Entity<PagamentoDominio>().Property(x => x.FormaPagamento).IsRequired().HasMaxLength(3).HasDefaultValue("DHR");
        }

        internal static PagamentoMap createInstance(ModelBuilder builder)
        {
            return new PagamentoMap(builder);
        }
    }
}
