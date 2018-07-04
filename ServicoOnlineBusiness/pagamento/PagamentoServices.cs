using ServicoOnlineBusiness.bases.banco.interfaces;
using ServicoOnlineBusiness.pagamento.abstracts;
using ServicoOnlineBusiness.pagamento.configuracao;
using ServicoOnlineBusiness.pagamento.dominio.entidade;
using ServicoOnlineBusiness.pagamento.dominio.interfaces;
using ServicoOnlineBusiness.pagamento.repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoOnlineBusiness.pagamento
{
    internal class PagamentoServices : PagamentoAbstract
    {
        #region "Atributos privados"
        private PagamentoRepositorio Repositorio = null;
        private PagamentoItemRepositorio repositorioItem = null;
        private IPagamentoDominio Pagamento = null;
        #endregion
        private PagamentoServices(ISqlBase sqlBase, IsolationLevel isolationLevel) : base(sqlBase, isolationLevel)
        {
            this.Repositorio = PagamentoRepositorio.Create(this.optionsBuilder.Options, isolationLevel);
        }
        internal static PagamentoAbstract Create(ISqlBase sqlBase, IsolationLevel isolationLevel)
        {
            return new PagamentoServices(sqlBase, isolationLevel);
        }
        public override IPagamentoDominio Incluir(IPagamentoDominio pagamento)
        {
            Repositorio.createTransacao();
            try
            {
                PagamentoDominio pagamentoDominio = ConverterPagamento.converterIPagamentoDominioParaPagamentoDominio(pagamento);
                Task<int> resgistrosAfetados = incluirPagamento(pagamentoDominio);

                if (resgistrosAfetados.Result > 0)
                    Repositorio.Commit();
                else
                    Repositorio.Rollback();

                this.Pagamento = ConverterPagamento.converterPagamentoDominioParaIPagamentoDominio(pagamentoDominio);
            }
           
            catch (Exception ex)
            {
                Repositorio.Rollback();
                throw ex;
            }
            return this.Pagamento;
        }

        #region "Métodos privados"
        private Task<int> incluirPagamento(PagamentoDominio pagamento)
        {
            try
            {
                Repositorio.Adicionar(pagamento);
                Task<int> resgistrosAfetados = Repositorio.SalvarAsync();

                return resgistrosAfetados;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
