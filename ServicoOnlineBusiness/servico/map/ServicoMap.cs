using Microsoft.EntityFrameworkCore;
using ServicoOnlineBusiness.servico.dominio.entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineBusiness.servico.map
{
    internal class ServicoMap
    {
        private ServicoMap(ModelBuilder builder)
        {
            builder.Entity<ServicoDominio>().ToTable("Servico", "db");
            builder.Entity<ServicoDominio>().HasKey(x => x.Id);
            builder.Entity<ServicoDominio>().Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Entity<ServicoDominio>().Property(x => x.Nome).HasMaxLength(50).IsRequired();
            builder.Entity<ServicoDominio>().Property(x => x.Preco).IsRequired();
            builder.Entity<ServicoDominio>().Property(x => x.tipoServicoDominioId).IsRequired();
            builder.Entity<ServicoDominio>().Property(x => x.Indicacao).HasMaxLength(150);
            builder.Entity<ServicoDominio>().Property(x => x.Descricao).HasMaxLength(1000);
            builder.Entity<ServicoDominio>().Property(x => x.Status).HasMaxLength(2).HasDefaultValue("AT");
        }

        internal static ServicoMap createInstance(ModelBuilder builder)
        {
            return new ServicoMap(builder);
        }
    }
}
