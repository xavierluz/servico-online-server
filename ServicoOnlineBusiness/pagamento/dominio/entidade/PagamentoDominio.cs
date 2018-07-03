using ServicoOnlineBusiness.pagamento.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineBusiness.pagamento.dominio.entidade
{
    public class PagamentoDominio : IPagamentoDominio
    {
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Nome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Telefone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FormaPagamento { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Descricao { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
