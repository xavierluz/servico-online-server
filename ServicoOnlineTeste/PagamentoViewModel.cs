using ServicoOnlineBusiness.pagamento.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineTeste
{
    class PagamentoViewModel : IPagamentoDominio
    {
        public PagamentoViewModel()
        {
            IPagamentoItemDominios = new List<IPagamentoItemDominio>();
        } 
        public Guid Id { get ; set ; }
        public string Nome { get ; set ; }
        public string Telefone { get ; set ; }
        public string Email { get ; set ; }
        public string FormaPagamento { get ; set ; }
        public string Descricao { get ; set ; }
        public string Status { get ; set ; }
        public ICollection<IPagamentoItemDominio> IPagamentoItemDominios { get ; set ; }
    }
}
