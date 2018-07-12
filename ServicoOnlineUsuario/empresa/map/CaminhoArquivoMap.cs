using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ServicoOnlineUsuario.empresa.dominio.entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineUsuario.empresa.map
{
    internal class CaminhoArquivoMap
    {
        private CaminhoArquivoMap(ModelBuilder builder)
        {

            builder.Entity<CaminhoArquivo>().ToTable("CaminhoArquivo", "dbo");
            builder.Entity<CaminhoArquivo>().HasKey(x => x.Id);
            builder.Entity<CaminhoArquivo>().Property(x => x.Id).ValueGeneratedOnAdd()
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            builder.Entity<CaminhoArquivo>().Property(x => x.CaminhoBaseImagem).HasMaxLength(200).IsRequired();
            builder.Entity<CaminhoArquivo>().Property(x => x.CaminhoBaseDownload).HasMaxLength(200).IsRequired();
            builder.Entity<CaminhoArquivo>().Property(x => x.EmpresaId).IsRequired();
            builder.Entity<CaminhoArquivo>().Property(x => x.Status).HasMaxLength(2).IsRequired().HasDefaultValue("AT");
            builder.Entity<CaminhoArquivo>().HasIndex(p => p.EmpresaId).HasName("EmpresaIdIndex");
        }

        internal static CaminhoArquivoMap createInstance(ModelBuilder builder)
        {
            return new CaminhoArquivoMap(builder);
        }
    }
}
