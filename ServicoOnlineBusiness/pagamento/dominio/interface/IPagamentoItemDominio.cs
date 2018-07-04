using ServicoOnlineBusiness.servico.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineBusiness.pagamento.dominio.interfaces
{
    public interface IPagamentoItemDominio
    {
        Guid Id { get; set; }
        Guid PagamentoDominioId { get; set; }
        IPagamentoDominio IPagamentoDominio { get; set; }
        int Quantidade { get; set; }
        Int32 ServicoDominioId { get; set; }
        IServicoDominio IServicoDominio { get; set; }
        String Status { get; set; }
    }
}
