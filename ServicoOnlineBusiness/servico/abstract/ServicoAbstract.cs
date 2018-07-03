using Microsoft.EntityFrameworkCore;
using ServicoOnlineBusiness.bases.banco.interfaces;
using ServicoOnlineBusiness.bases.contexto;
using ServicoOnlineBusiness.servico.dominio.entidade;
using ServicoOnlineBusiness.servico.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ServicoOnlineBusiness.servico.abstracts
{
    public abstract class ServicoAbstract
    {
        internal DbContextOptionsBuilder<ServicoContexto> optionsBuilder;
        protected IsolationLevel isolationLevel;
        protected ServicoAbstract(ISqlBase sqlBase, IsolationLevel isolationLevel)
        {
            this.isolationLevel = isolationLevel;
            this.optionsBuilder = new DbContextOptionsBuilder<ServicoContexto>();
            this.optionsBuilder.UseSqlServer(sqlBase.getConnection());

        }

        public abstract Task<List<IServicoDominio>> Gets(int tipoServicoId);
    }
}
