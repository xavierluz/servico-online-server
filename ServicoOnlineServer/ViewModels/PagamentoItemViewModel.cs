using ServicoOnlineBusiness.pagamento.dominio.interfaces;
using ServicoOnlineBusiness.servico.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoOnlineServer.ViewModels
{
    public class PagamentoItemViewModel : IPagamentoItemDominio
    {
        public Guid Id { get; set; }
        public Guid PagamentoDominioId { get; set; }
        public IPagamentoDominio IPagamentoDominio { get; set; }
        public int Quantidade { get; set; }
        public int ServicoDominioId { get; set; }
        public IServicoDominio IServicoDominio { get; set; }
        public string Status { get; set; }
    }
}
