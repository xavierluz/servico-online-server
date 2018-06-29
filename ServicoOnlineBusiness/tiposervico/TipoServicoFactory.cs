using ServicoOnlineBusiness.bases.banco.interfaces;
using ServicoOnlineBusiness.bases.banco.sqlServer;
using ServicoOnlineBusiness.tiposervico.abstracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ServicoOnlineBusiness.tiposervico
{
    public class TipoServicoFactory
    {
        private IsolationLevel isolationLevel = IsolationLevel.Unspecified;
        private ISqlBase sqlBase = null;

        private TipoServicoFactory(IsolationLevel isolationLevel)
        {
            sqlBase = SqlServerFactory.Create();
            this.isolationLevel = isolationLevel;
        }
        public static TipoServicoFactory Create(IsolationLevel isolationLevel)
        {
            return new TipoServicoFactory(isolationLevel);
        }

        public TipoServicoAbstract getTipoServico()
        {
            return TipoServicoServices.Create(this.sqlBase, this.isolationLevel);
        }
    }
}
