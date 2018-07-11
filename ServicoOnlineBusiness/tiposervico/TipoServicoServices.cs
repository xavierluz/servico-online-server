using Microsoft.EntityFrameworkCore;
using ServicoOnlineBusiness.bases.banco.interfaces;
using ServicoOnlineBusiness.bases.extensao;
using ServicoOnlineBusiness.tiposervico.abstracts;
using ServicoOnlineBusiness.tiposervico.configuracao;
using ServicoOnlineBusiness.tiposervico.dominio.entidade;
using ServicoOnlineBusiness.tiposervico.dominio.interfaces;
using ServicoOnlineBusiness.tiposervico.repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoOnlineBusiness.tiposervico
{
    internal class TipoServicoServices: TipoServicoAbstract
    {
        #region "Atributos privados"
        private TipoServicoRepositorio Repositorio = null;
        private ITipoServicoDominio TipoServicoDominio = null;
        #endregion
        private TipoServicoServices(ISqlBase sqlBase, IsolationLevel isolationLevel) : base(sqlBase, isolationLevel)
        {
            this.Repositorio = TipoServicoRepositorio.Create(this.optionsBuilder.Options, isolationLevel);
        }
       
        internal static TipoServicoServices Create(ISqlBase sqlBase, IsolationLevel isolationLevel)
        {
            return new TipoServicoServices(sqlBase, isolationLevel);
        }
       
        public override Task<List<ITipoServicoDominio>> Gets()
        {
            IQueryable<TipoServicoDominio> query = (from q in this.Repositorio.Contexto.Set<TipoServicoDominio>() select q);

            Task<List<TipoServicoDominio>> tipoServicos = this.Repositorio.Set(query).Get().ToListAsync();

            var ITipoServicos = tipoServicos.Result.ConvertAll(new Converter<TipoServicoDominio, ITipoServicoDominio>(ConverterTipoServico.converterTipoServicoDominioParaITipoServicoDominio)).ToAsyncEnumerable();

            return ITipoServicos.ToList();
        }

        public override ITipoServicoDominio Get(int Id)
        {

            TipoServicoDominio tipoServico = consultarPorId(Id);

            var ITipoServico = ConverterTipoServico.converterTipoServicoDominioParaITipoServicoDominio(tipoServico);

            return ITipoServico;
        }

        public async override Task<TipoServicoAbstract> Incluir(ITipoServicoDominio tipoServicoDominio)
        {
            TipoServicoDominio _tipoServicoDominio = ConverterTipoServico.converterITipoServicoDominioParaTipoServicoDominio(tipoServicoDominio);
            this.Repositorio.createTransacao();
            try
            {
                this.Repositorio.Adicionar(_tipoServicoDominio);
                Task<int> registrosAfetados = this.Repositorio.SalvarAsync();

                if (registrosAfetados.Result > 0)
                    this.Repositorio.Commit();
                else
                    this.Repositorio.Rollback();

                await registrosAfetados;

                TipoServicoDominio = ConverterTipoServico.converterTipoServicoDominioParaITipoServicoDominio(_tipoServicoDominio);
            }
            catch(Exception ex)
            {
                this.Repositorio.Rollback();
                throw ex;
            }
            return this;
        }

        public async override Task<TipoServicoAbstract> Alterar(ITipoServicoDominio tipoServicoDominio)
        {
            this.TipoServicoDominio = tipoServicoDominio;
            this.Repositorio.createTransacao();
            TipoServicoDominio tipoServico = consultarPorId(tipoServicoDominio.Id);
            if(tipoServico != null)
            {
                tipoServico.Nome = tipoServicoDominio.Nome;
                tipoServico.Status = tipoServicoDominio.Status;
                tipoServico.Descricao = tipoServicoDominio.Descricao;

                this.Repositorio.Atualizar(tipoServico);
                Task<int> registrosAfetados = this.Repositorio.SalvarAsync();

                if (registrosAfetados.Result > 0)
                    this.Repositorio.Commit();
                else
                    this.Repositorio.Rollback();

                await registrosAfetados;
                this.TipoServicoDominio = ConverterTipoServico.converterTipoServicoDominioParaITipoServicoDominio(tipoServico);
            }
           

            return this;
        }

        private TipoServicoDominio consultarPorId(int Id)
        {
            IQueryable<TipoServicoDominio> query = (from q in this.Repositorio.Contexto.Set<TipoServicoDominio>() where q.Id == Id select q);

            Task<TipoServicoDominio> tipoServico = this.Repositorio.Set(query).Get().FirstOrDefaultAsync();
            return tipoServico.Result;
        }

        public override ITipoServicoDominio Get()
        {
            return TipoServicoDominio;
        }

        public override Task<List<ITipoServicoDominio>> Gets(int paginaIndex, string filtro, int registroPorPagina)
        {
            throw new NotImplementedException();
        }
    }
}
