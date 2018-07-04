using Microsoft.EntityFrameworkCore;
using ServicoOnlineBusiness.bases.banco.interfaces;
using ServicoOnlineBusiness.bases.contexto;
using ServicoOnlineBusiness.pagamento.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ServicoOnlineBusiness.pagamento.abstracts
{
    public abstract class PagamentoAbstract
    {
        internal DbContextOptionsBuilder<ServicoContexto> optionsBuilder;
        protected IsolationLevel isolationLevel;
        protected PagamentoAbstract(ISqlBase sqlBase, IsolationLevel isolationLevel)
        {
            this.isolationLevel = isolationLevel;
            this.optionsBuilder = new DbContextOptionsBuilder<ServicoContexto>();
            this.optionsBuilder.UseSqlServer(sqlBase.getConnection());

        }

        public abstract IPagamentoDominio Incluir(IPagamentoDominio pagamento);
    }
}
