using ServicoOnlineBusiness.bases.banco.interfaces;
using ServicoOnlineBusiness.bases.banco.sqlServer;
using ServicoOnlineBusiness.pagamento;
using ServicoOnlineBusiness.pagamento.abstracts;
using ServicoOnlineBusiness.servico;
using ServicoOnlineBusiness.servico.abstracts;
using ServicoOnlineBusiness.tiposervico;
using ServicoOnlineBusiness.tiposervico.abstracts;
using System.Data;

namespace ServicoOnlineBusiness.factory
{
    public class ServicoFactory
    {
        private IsolationLevel isolationLevel = IsolationLevel.Unspecified;
        private ISqlBase sqlBase = null;

        private ServicoFactory(IsolationLevel isolationLevel)
        {
            sqlBase = SqlServerFactory.Create();
            this.isolationLevel = isolationLevel;
        }
        public static ServicoFactory Create(IsolationLevel isolationLevel)
        {
            return new ServicoFactory(isolationLevel);
        }

        public TipoServicoAbstract getTipoServico()
        {
            return TipoServicoServices.Create(this.sqlBase, this.isolationLevel);
        }
        public TipoServicoAbstract getTipoServicoAdmin(string token)
        {
            return TipoServicesAdmin.Create(this.sqlBase, this.isolationLevel, token);
        }
        public ServicoAbstract getServico()
        {
            return ServicoServices.Create(this.sqlBase, this.isolationLevel);
        }
        public PagamentoAbstract getPagamento()
        {
            return PagamentoServices.Create(this.sqlBase, this.isolationLevel);
        }
    }
}
