﻿using Microsoft.EntityFrameworkCore;
using ServicoOnlineBusiness.bases.banco.interfaces;
using ServicoOnlineBusiness.bases.contexto;
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
        internal DbContextOptionsBuilder<ServicoContexto> optionsBuilder;
        protected IsolationLevel isolationLevel;
        protected string token;
        protected TipoServicoAbstract(ISqlBase sqlBase, IsolationLevel isolationLevel)
        {
            this.isolationLevel = isolationLevel;
            this.optionsBuilder = new DbContextOptionsBuilder<ServicoContexto>();
            this.optionsBuilder.UseSqlServer(sqlBase.getConnection());

        }
        protected TipoServicoAbstract(ISqlBase sqlBase, IsolationLevel isolationLevel, string token)
        {
            this.token = token;
            this.isolationLevel = isolationLevel;
            this.optionsBuilder = new DbContextOptionsBuilder<ServicoContexto>();
            this.optionsBuilder.UseSqlServer(sqlBase.getConnection());

        }
        public abstract ITipoServicoDominio Get();
        public abstract Task<List<ITipoServicoDominio>> GetsAsync();
        public abstract List<ITipoServicoDominio> Gets();
        public abstract Task<List<ITipoServicoDominio>> Gets(int paginaIndex, string filtro, int registroPorPagina);
        public abstract ITipoServicoDominio Get(int Id);
        public abstract Task<TipoServicoAbstract> Incluir(ITipoServicoDominio tipoServicoDominio);
        public abstract Task<TipoServicoAbstract> Alterar(ITipoServicoDominio tipoServicoDominio);
    }
}
