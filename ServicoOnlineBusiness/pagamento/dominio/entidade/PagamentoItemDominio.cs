using ServicoOnlineBusiness.pagamento.dominio.interfaces;
using ServicoOnlineBusiness.servico.dominio.entidade;
using ServicoOnlineBusiness.servico.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ServicoOnlineBusiness.pagamento.dominio.entidade
{
    public class PagamentoItemDominio : IPagamentoItemDominio
    {
        protected PagamentoItemDominio() { }
        internal static PagamentoItemDominio Create()
        {
            return new PagamentoItemDominio();
        }
        public Guid Id { get; set; }
        [NotMapped]
        public IPagamentoDominio IPagamentoDominio { get; set; }
        public virtual PagamentoDominio PagamentoDominio { get; set; }
        public virtual Guid PagamentoDominioId { get; set; }
        public int Quantidade { get; set; }
        [NotMapped]
        public IServicoDominio IServicoDominio { get; set; }
        public string Status { get; set; }
        public virtual ServicoDominio ServicoDominio { get; set; }
        public virtual int ServicoDominioId { get; set; }
    }
}
