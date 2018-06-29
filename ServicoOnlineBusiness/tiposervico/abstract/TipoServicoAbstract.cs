using Microsoft.EntityFrameworkCore;
using ServicoOnlineBusiness.bases.banco.interfaces;
using ServicoOnlineBusiness.tiposervico.contexto;
using ServicoOnlineBusiness.tiposervico.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ServicoOnlineBusiness.tiposervico.abstracts
{
    public abstract class TipoServicoAbstract
    {
        internal DbContextOptionsBuilder<TipoServicoDbContexto> optionsBuilder;
        protected IsolationLevel isolationLevel;
        protected TipoServicoAbstract(ISqlBase sqlBase, IsolationLevel isolationLevel)
        {
            this.isolationLevel = isolationLevel;
            this.optionsBuilder = new DbContextOptionsBuilder<TipoServicoDbContexto>();
            this.optionsBuilder.UseSqlServer(sqlBase.getConnection());

        }

        public abstract Task<List<ITipoServicoDominio>> Gets();
    }
}
