using ServicoOnlineBusiness.pagamento.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace ServicoOnlineBusiness.pagamento.dominio.entidade
{
    public class PagamentoDominio : IPagamentoDominio
    {
        protected PagamentoDominio()
        {
            this.IPagamentoItemDominios = new List<IPagamentoItemDominio>();
            this.PagamentoItemDominios = new List<PagamentoItemDominio>();
        }
        internal static PagamentoDominio Create()
        {
            return new PagamentoDominio();
        }
        
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string FormaPagamento { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        [NotMapped]
        public ICollection<IPagamentoItemDominio> IPagamentoItemDominios { get; set; }
        public virtual ICollection<PagamentoItemDominio> PagamentoItemDominios { get; set; }
        public string NumeroDocumento { get; set; }
    }
}
