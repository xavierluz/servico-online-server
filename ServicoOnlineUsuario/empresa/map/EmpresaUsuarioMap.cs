using Microsoft.EntityFrameworkCore;
using ServicoOnlineUsuario.empresa.dominio.entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineUsuario.empresa.map
{
    internal class EmpresaUsuarioMap
    {
        private EmpresaUsuarioMap(ModelBuilder builder)
        {

            builder.Entity<EmpresaUsuario>().ToTable("EmpresaUsuario", "dbo");
            builder.Entity<EmpresaUsuario>().HasKey(x => new {x.EmpresaId,x.UsuarioId }).HasName("PK_EmpresaUsuario");
            builder.Entity<EmpresaUsuario>().Property(x => x.EmpresaId).IsRequired();
            builder.Entity<EmpresaUsuario>().Property(x => x.UsuarioId).IsRequired().HasMaxLength(50);
            builder.Entity<EmpresaUsuario>().Property(x => x.Key).IsRequired();
            builder.Entity<EmpresaUsuario>().Property(x => x.Status).HasMaxLength(2).IsRequired().HasDefaultValue("AT");
            builder.Entity<EmpresaUsuario>().HasIndex(p => p.EmpresaId).HasName("EmpresaIdIndex");
            builder.Entity<EmpresaUsuario>().HasIndex(p => p.UsuarioId).IsUnique().HasName("UsuarioIdIndex");
        }

        internal static EmpresaUsuarioMap createInstance(ModelBuilder builder)
        {
            return new EmpresaUsuarioMap(builder);
        }
    }
}
