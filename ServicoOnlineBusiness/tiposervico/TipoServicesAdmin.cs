using Microsoft.EntityFrameworkCore;
using ServicoOnlineBusiness.bases.banco.interfaces;
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
    internal class TipoServicesAdmin : TipoServicoAbstract
    {
        #region "Atributos privados"
        private TipoServicoRepositorio Repositorio = null;
        private ITipoServicoDominio TipoServicoDominio = null;
        #endregion
        private TipoServicesAdmin(ISqlBase sqlBase, IsolationLevel isolationLevel, string token) : base(sqlBase, isolationLevel, token)
        {
            this.Repositorio = TipoServicoRepositorio.Create(this.optionsBuilder.Options, isolationLevel);
        }

        internal static TipoServicesAdmin Create(ISqlBase sqlBase, IsolationLevel isolationLevel, string token)
        {
            return new TipoServicesAdmin(sqlBase, isolationLevel, token);
        }

        public override Task<TipoServicoAbstract> Alterar(ITipoServicoDominio tipoServicoDominio)
        {
            throw new NotImplementedException();
        }

        public override ITipoServicoDominio Get()
        {
            throw new NotImplementedException();
        }

        public override ITipoServicoDominio Get(int Id)
        {
            throw new NotImplementedException();
        }

        public override Task<List<ITipoServicoDominio>> GetsAsync()
        {
            try
            {
                this.Repositorio.createTransacao();
                IQueryable<TipoServicoDominio> query = (from q in this.Repositorio.Contexto.Set<TipoServicoDominio>()
                                                        where q.Status !="INA"
                                                        select q);

                Task<List<TipoServicoDominio>> tipoServicos = this.Repositorio.Set(query).Get().ToListAsync();
                this.Repositorio.Commit();
                var ITipoServicos = tipoServicos.Result.ConvertAll(new Converter<TipoServicoDominio, ITipoServicoDominio>(ConverterTipoServico.converterTipoServicoDominioParaITipoServicoDominio)).ToAsyncEnumerable();

                return ITipoServicos.ToList();
            }catch(Exception ex)
            {
                this.Repositorio.Rollback();
                throw ex;
            }
        }

        public async override Task<List<ITipoServicoDominio>> Gets(int paginaIndex, string filtro, int registroPorPagina)
        {
            try
            {
                IQueryable<TipoServicoDominio> query = null;
                Task<List<TipoServicoDominio>> tipoServicos;

                int _totalRegistro;

                if (paginaIndex < 0)
                    paginaIndex = 0;

                this.Repositorio.createTransacao();

                if (!string.IsNullOrEmpty(filtro) &&
                   !string.IsNullOrWhiteSpace(filtro))
                {
                    query = (from q in this.Repositorio.Contexto.Set<TipoServicoDominio>()
                             where q.Status != "INA"
                                && q.Nome.ToUpper().Contains(filtro.ToUpper())
                                && q.Status.ToUpper().Contains(filtro.ToUpper())
                                && q.Descricao.ToUpper().Contains(filtro.ToUpper())
                             select q);
                    _totalRegistro = await this.Repositorio.Set(query).Get().CountAsync();

                    query = (from q in this.Repositorio.Contexto.Set<TipoServicoDominio>()
                            where q.Status != "INA"
                               && q.Nome.ToUpper().Contains(filtro.ToUpper())
                               && q.Status.ToUpper().Contains(filtro.ToUpper())
                               && q.Descricao.ToUpper().Contains(filtro.ToUpper())
                            select q).Skip(paginaIndex).Take(registroPorPagina).AsQueryable();


                }
                else
                {
                    query = (from q in this.Repositorio.Contexto.Set<TipoServicoDominio>()
                             where q.Status != "INA"
                             select q);
                    _totalRegistro = await this.Repositorio.Set(query).Get().CountAsync();

                    query = (from q in this.Repositorio.Contexto.Set<TipoServicoDominio>()
                             where q.Status != "INA"
                             select q).Skip(paginaIndex).Take(registroPorPagina).AsQueryable();


                }

                tipoServicos = this.Repositorio.Set(query).Get().ToListAsync();

                this.Repositorio.Commit();
                var ITipoServicos = tipoServicos.Result.ConvertAll(new Converter<TipoServicoDominio, ITipoServicoDominio>(ConverterTipoServico.converterTipoServicoDominioParaITipoServicoDominio));

                return ITipoServicos;
            }
            catch (Exception ex)
            {
                this.Repositorio.Rollback();
                throw ex;
            }
        }

        public override Task<TipoServicoAbstract> Incluir(ITipoServicoDominio tipoServicoDominio)
        {
            throw new NotImplementedException();
        }

        public override List<ITipoServicoDominio> Gets()
        {
            throw new NotImplementedException();
        }
    }
}
