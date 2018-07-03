using ServicoOnlineBusiness.bases.banco.interfaces;
using ServicoOnlineBusiness.bases.banco.sqlServer;
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
        public ServicoAbstract getServico()
        {
            return ServicoServices.Create(this.sqlBase, this.isolationLevel);
        }
    }
}
