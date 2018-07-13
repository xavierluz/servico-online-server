using Microsoft.EntityFrameworkCore;
using ServicoOnlineBusiness.tiposervico.dominio.entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineBusiness.tiposervico.map
{
    internal class TipoServicoMap
    {
        private TipoServicoMap(ModelBuilder builder)
        {
            builder.Entity<TipoServicoDominio>().ToTable("TipoServico", "dbo");
            builder.Entity<TipoServicoDominio>().HasKey(x => x.Id);
            builder.Entity<TipoServicoDominio>().Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Entity<TipoServicoDominio>().Property(x => x.Nome).HasMaxLength(50).IsRequired();
            builder.Entity<TipoServicoDominio>().Property(x => x.caminhoDaImage).HasMaxLength(200);
            builder.Entity<TipoServicoDominio>().Property(x => x.Descricao).HasMaxLength(500);
            builder.Entity<TipoServicoDominio>().Property(x => x.Status).HasMaxLength(2).HasDefaultValue("AT");
        }

        internal static TipoServicoMap createInstance(ModelBuilder builder)
        {
            return new TipoServicoMap(builder);
        }
    }
}
