using Microsoft.EntityFrameworkCore;
using ServicoOnlineBusiness.bases.banco.interfaces;
using ServicoOnlineBusiness.servico.abstracts;
using ServicoOnlineBusiness.servico.configuracao;
using ServicoOnlineBusiness.servico.dominio.entidade;
using ServicoOnlineBusiness.servico.dominio.interfaces;
using ServicoOnlineBusiness.servico.repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoOnlineBusiness.servico
{
    internal class ServicoServices : ServicoAbstract
    {
        #region "Atributos privados"
        private ServicoRepositorio Repositorio = null;

        #endregion
        private ServicoServices(ISqlBase sqlBase, IsolationLevel isolationLevel) : base(sqlBase, isolationLevel)
        {
            this.Repositorio = ServicoRepositorio.Create(this.optionsBuilder.Options, isolationLevel);
        }
        internal static ServicoServices Create(ISqlBase sqlBase, IsolationLevel isolationLevel)
        {
            return new ServicoServices(sqlBase, isolationLevel);
        }
        public async override Task<List<IServicoDominio>> Gets(int tipoServicoId)
        {
            IQueryable<ServicoDominio> query = (from q in this.Repositorio.Contexto.Set<ServicoDominio>()
                                                where q.tipoServicoDominio.Id == tipoServicoId
                                                select q).Include(x=> x.tipoServicoDominio);

            List<ServicoDominio> Servicos = await this.Repositorio.Set(query).Get().ToListAsync();

            var IServicos = Servicos.ConvertAll(new Converter<ServicoDominio, IServicoDominio>(ConverterServico.converterServicoDominioParaIServicoDominio));

            return IServicos.ToList();
        }
    }
}
