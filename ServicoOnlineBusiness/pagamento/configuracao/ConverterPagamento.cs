using ServicoOnlineBusiness.pagamento.dominio.entidade;
using ServicoOnlineBusiness.pagamento.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoOnlineBusiness.pagamento.configuracao
{
    internal static class ConverterPagamento
    {
        internal static PagamentoDominio converterIPagamentoDominioParaPagamentoDominio(IPagamentoDominio pagamentoDominio)
        {
            PagamentoDominio _pagamentoDominio = null;
            if(pagamentoDominio != null)
            {
                _pagamentoDominio = PagamentoDominio.Create();

                _pagamentoDominio.Descricao = pagamentoDominio.Descricao;
                _pagamentoDominio.Email = pagamentoDominio.Email;
                _pagamentoDominio.FormaPagamento = pagamentoDominio.FormaPagamento;
                _pagamentoDominio.Id = pagamentoDominio.Id;
                _pagamentoDominio.Nome = pagamentoDominio.Nome;
                _pagamentoDominio.Status = pagamentoDominio.Status;
                _pagamentoDominio.Telefone = pagamentoDominio.Telefone;
                _pagamentoDominio.PagamentoItemDominios = pagamentoDominio.IPagamentoItemDominios.ToList().ConvertAll(new Converter<IPagamentoItemDominio, PagamentoItemDominio>(setPagamentoItemDominio));
            }

            return _pagamentoDominio;
        }

        private static PagamentoItemDominio setPagamentoItemDominio(IPagamentoItemDominio pagamentoItemDominio)
        {
            PagamentoItemDominio _pagamentoItemDominio = null;

            if(pagamentoItemDominio != null)
            {
                _pagamentoItemDominio = PagamentoItemDominio.Create();
                _pagamentoItemDominio.Id = pagamentoItemDominio.Id;
                _pagamentoItemDominio.PagamentoDominioId = pagamentoItemDominio.PagamentoDominioId;
                _pagamentoItemDominio.Quantidade = pagamentoItemDominio.Quantidade;
                _pagamentoItemDominio.ServicoDominioId = pagamentoItemDominio.ServicoDominioId;
                _pagamentoItemDominio.Status = pagamentoItemDominio.Status;
                
            }

            return _pagamentoItemDominio;
        }

        internal static IPagamentoDominio converterPagamentoDominioParaIPagamentoDominio(PagamentoDominio pagamentoDominio)
        {
            IPagamentoDominio _pagamentoDominio = null;
            if (pagamentoDominio != null)
            {
                _pagamentoDominio = PagamentoDominio.Create();

                _pagamentoDominio.Descricao = pagamentoDominio.Descricao;
                _pagamentoDominio.Email = pagamentoDominio.Email;
                _pagamentoDominio.FormaPagamento = pagamentoDominio.FormaPagamento;
                _pagamentoDominio.Id = pagamentoDominio.Id;
                _pagamentoDominio.Nome = pagamentoDominio.Nome;
                _pagamentoDominio.Status = pagamentoDominio.Status;
                _pagamentoDominio.Telefone = pagamentoDominio.Telefone;
                _pagamentoDominio.IPagamentoItemDominios = pagamentoDominio.PagamentoItemDominios.ToList().ConvertAll(new Converter<PagamentoItemDominio, IPagamentoItemDominio>(setIPagamentoItemDominio));
            }

            return _pagamentoDominio;
        }
        
        private static IPagamentoItemDominio setIPagamentoItemDominio(PagamentoItemDominio pagamentoItemDominio)
        {
            IPagamentoItemDominio _pagamentoItemDominio = null;

            if (pagamentoItemDominio != null)
            {
                _pagamentoItemDominio = PagamentoItemDominio.Create();
                _pagamentoItemDominio.Id = _pagamentoItemDominio.Id;
                _pagamentoItemDominio.PagamentoDominioId = _pagamentoItemDominio.PagamentoDominioId;
                _pagamentoItemDominio.Quantidade = _pagamentoItemDominio.Quantidade;
                _pagamentoItemDominio.ServicoDominioId = _pagamentoItemDominio.ServicoDominioId;
                _pagamentoItemDominio.Status = _pagamentoItemDominio.Status;

            }

            return _pagamentoItemDominio;
        }

        public static PagamentoItemDominio converterIPagamentoItemDominioParaPagamentoItemDominio(IPagamentoItemDominio pagamentoItemDominio)
        {
            PagamentoItemDominio _pagamentoItemDominio = null;

            if (pagamentoItemDominio != null)
            {
                _pagamentoItemDominio = PagamentoItemDominio.Create();
                _pagamentoItemDominio.Id = pagamentoItemDominio.Id;
                _pagamentoItemDominio.PagamentoDominioId = pagamentoItemDominio.PagamentoDominioId;
                _pagamentoItemDominio.Quantidade = pagamentoItemDominio.Quantidade;
                _pagamentoItemDominio.ServicoDominioId = pagamentoItemDominio.ServicoDominioId;
                _pagamentoItemDominio.Status = pagamentoItemDominio.Status;

            }

            return _pagamentoItemDominio;
        }
    }
}
