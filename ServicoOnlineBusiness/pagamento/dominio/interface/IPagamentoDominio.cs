using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineBusiness.pagamento.dominio.interfaces
{
    public interface IPagamentoDominio
    {
        Guid Id { get; set; }
        String Nome { get; set; }
        String Telefone { get; set; }
        String Email { get; set; }
        String FormaPagamento { get; set; }
        String Descricao { get; set; }
        String Status { get; set; }
        ICollection<IPagamentoItemDominio> IPagamentoItemDominios { get; set; }
    }
}
