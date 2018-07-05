using ServicoOnlineBusiness.pagamento.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoOnlineServer.ViewModels
{
    public class PagamentoViewModel : IPagamentoDominio
    {
        public PagamentoViewModel()
        {
            this.IPagamentoItemDominios = new List<IPagamentoItemDominio>();
            this.PagamentoItemViewModels = new List<PagamentoItemViewModel>();
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string FormaPagamento { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public ICollection<IPagamentoItemDominio> IPagamentoItemDominios { get; set; }
        public ICollection<PagamentoItemViewModel> PagamentoItemViewModels { get; set; }
        public string NumeroDocumento { get ; set; }
    }
}
