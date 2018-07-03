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
            IQueryable<TipoServicoDominio> query = (from q in this.Repositorio.Contexto.Set<TipoServicoDominio>() where q.Id == Id select q);

            Task<TipoServicoDominio> tipoServico = this.Repositorio.Set(query).Get().FirstOrDefaultAsync();

            var ITipoServico = ConverterTipoServico.converterTipoServicoDominioParaITipoServicoDominio(tipoServico.Result);

            return ITipoServico;
        }
    }
}
