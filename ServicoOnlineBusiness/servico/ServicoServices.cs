using Microsoft.EntityFrameworkCore;
using ServicoOnlineBusiness.bases.banco.interfaces;
using ServicoOnlineBusiness.bases.retorno;
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
        private AcoesResutado resultado = null;
        #endregion
        private ServicoServices(ISqlBase sqlBase, IsolationLevel isolationLevel) : base(sqlBase, isolationLevel)
        {
            this.Repositorio = ServicoRepositorio.Create(this.optionsBuilder.Options, isolationLevel);
            
        }
        internal static ServicoServices Create(ISqlBase sqlBase, IsolationLevel isolationLevel)
        {
            return new ServicoServices(sqlBase, isolationLevel);
        }

        public override async Task<AcoesResutado> Incluir(IServicoDominio servicoDominio)
        {
            this.resultado = new AcoesResutado();
            try
            {
                var servico = ConverterServico.converterIServicoDominioParaServicoDominio(servicoDominio);

                this.Repositorio.Adicionar(servico);
                Task<int> resitroAfetados = this.Repositorio.SalvarAsync();

                if (resitroAfetados.Exception != null)
                {
                    this.resultado.Falhou(resitroAfetados.Exception);
                }
                await resitroAfetados;
            }
            catch (Exception ex)
            {
                this.resultado.Falhou(ex);
            }
            return this.resultado;
        }

        public async override Task<List<IServicoDominio>> Gets(int tipoServicoId)
        {

            this.Repositorio.createTransacao();
            try
            {
                IQueryable<ServicoDominio> query = (from q in this.Repositorio.Contexto.Set<ServicoDominio>()
                                                    where q.tipoServicoDominio.Id == tipoServicoId
                                                    select q).Include(x => x.tipoServicoDominio);

                List<ServicoDominio> Servicos = await this.Repositorio.Set(query).Get().ToListAsync();
                this.Repositorio.Commit();
                var IServicos = Servicos.ConvertAll(new Converter<ServicoDominio, IServicoDominio>(ConverterServico.converterServicoDominioParaIServicoDominio));
                return IServicos.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }

           

        }
    }
}
