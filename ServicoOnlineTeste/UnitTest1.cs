using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicoOnlineBusiness.factory;
using ServicoOnlineBusiness.pagamento.dominio.interfaces;
using System.Data;

namespace ServicoOnlineTeste
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted;

            ServicoFactory factory = ServicoFactory.Create(isolationLevel);
            var Pagamento = factory.getPagamento();

            IPagamentoDominio pagamento = new PagamentoViewModel();

            pagamento.Descricao = "Teste do celso segundo teste";
            pagamento.Email = "xavierluz@gmail.com";
            pagamento.FormaPagamento = "CAT";
            pagamento.Nome = "Celso Xavier Luz";
            pagamento.Status = "AT";
            pagamento.Telefone = "11951214906";

            IPagamentoItemDominio pagamentoItem = new PagamentoItemViewModel();
            pagamentoItem.Quantidade = 4;
            pagamentoItem.Status = "AT";
            pagamentoItem.ServicoDominioId = 1;
            pagamento.IPagamentoItemDominios.Add(pagamentoItem);
            pagamentoItem = new PagamentoItemViewModel();
            pagamentoItem.Quantidade = 1;
            pagamentoItem.Status = "AT";
            pagamentoItem.ServicoDominioId = 2;
            pagamento.IPagamentoItemDominios.Add(pagamentoItem);

            Pagamento.Incluir(pagamento);
        }
    }
}
