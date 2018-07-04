using Microsoft.EntityFrameworkCore;
using ServicoOnlineBusiness.pagamento.dominio.entidade;
using ServicoOnlineBusiness.servico.dominio.entidade;
using ServicoOnlineBusiness.tiposervico.dominio.entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineBusiness.bases.contexto
{
    class RelacionamentoServico
    {
        private RelacionamentoServico(ModelBuilder builder)
        {

        }

        internal static void Create(ModelBuilder modelBuilder)
        {
            new RelacionamentoServico(modelBuilder);
        }

        private void setRelacionamento(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoServicoDominio>()
                .HasMany(e => e.servicoDominios)
                .WithOne(e => e.tipoServicoDominio)
                .HasForeignKey(e => e.tipoServicoDominioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PagamentoDominio>()
                .HasMany(e => e.PagamentoItemDominios)
                .WithOne(e => e.PagamentoDominio).HasForeignKey(e => e.PagamentoDominioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PagamentoItemDominio>()
                .HasOne(x => x.ServicoDominio)
                .WithMany(x => x.PagamentoItemDominios)
                .HasForeignKey(x => x.ServicoDominioId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
