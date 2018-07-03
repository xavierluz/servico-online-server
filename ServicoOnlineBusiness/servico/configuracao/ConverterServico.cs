using ServicoOnlineBusiness.servico.dominio.entidade;
using ServicoOnlineBusiness.servico.dominio.interfaces;
using ServicoOnlineBusiness.tiposervico.dominio.entidade;
using ServicoOnlineBusiness.tiposervico.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineBusiness.servico.configuracao
{
    internal static class ConverterServico
    {
        internal static IServicoDominio converterServicoDominioParaIServicoDominio(ServicoDominio servicoDominio)
        {
            IServicoDominio _servicoDominio = null;
            if(servicoDominio != null)
            {
                _servicoDominio = ServicoDominio.Create();
                _servicoDominio.Descricao = servicoDominio.Descricao;
                _servicoDominio.Id = servicoDominio.Id;
                _servicoDominio.Indicacao = servicoDominio.Indicacao;
                _servicoDominio.ITipoServico = getITipoServicoDominio(servicoDominio.tipoServicoDominio);
                _servicoDominio.Nome = servicoDominio.Nome;
                _servicoDominio.Preco = servicoDominio.Preco;
                _servicoDominio.Status = servicoDominio.Status;
                _servicoDominio.tipoServicoDominioId = servicoDominio.tipoServicoDominioId;

            }

            return _servicoDominio;

        } 

        private static ITipoServicoDominio getITipoServicoDominio(TipoServicoDominio tipoServicoDominio)
        {
            ITipoServicoDominio _tipoServicoDominio = null;

            if (tipoServicoDominio != null)
            {
                _tipoServicoDominio = TipoServicoDominio.Create();
                _tipoServicoDominio.caminhoDaImage = tipoServicoDominio.caminhoDaImage;
                _tipoServicoDominio.Descricao = tipoServicoDominio.Descricao;
                _tipoServicoDominio.Id = tipoServicoDominio.Id;
                _tipoServicoDominio.Nome = tipoServicoDominio.Nome;
                _tipoServicoDominio.Status = tipoServicoDominio.Status;
            }

            return _tipoServicoDominio;
        }
    }
}
