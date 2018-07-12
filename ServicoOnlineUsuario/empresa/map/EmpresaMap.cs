using Microsoft.EntityFrameworkCore;
using ServicoOnlineUsuario.empresa.dominio.entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineUsuario.empresa.map
{
    internal class EmpresaMap
    {
        private EmpresaMap(ModelBuilder builder)
        {

            builder.Entity<Empresa>().ToTable("Empresa", "dbo");
            builder.Entity<Empresa>().HasKey(x => x.Id);
            builder.Entity<Empresa>().Property(x => x.Id).HasDefaultValue(Guid.NewGuid());
            builder.Entity<Empresa>().Property(x => x.Nome).HasMaxLength(100).IsRequired();
            builder.Entity<Empresa>().Property(x => x.NomeFantasia).HasMaxLength(200);
            builder.Entity<Empresa>().Property(x => x.Email).HasMaxLength(100);
            builder.Entity<Empresa>().Property(x => x.Status).HasMaxLength(2).IsRequired().HasDefaultValue("AT");
        }

        internal static EmpresaMap createInstance(ModelBuilder builder)
        {
            return new EmpresaMap(builder);
        }
    }
}
