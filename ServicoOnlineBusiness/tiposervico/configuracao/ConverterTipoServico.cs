using ServicoOnlineBusiness.tiposervico.dominio.entidade;
using ServicoOnlineBusiness.tiposervico.dominio.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoOnlineBusiness.tiposervico.configuracao
{
    internal static class ConverterTipoServico
    {
        internal static ITipoServicoDominio converterTipoServicoDominioParaITipoServicoDominio(TipoServicoDominio tipoServicoDominio)
        {
            ITipoServicoDominio _tipoServicoDominio = null;

            if(tipoServicoDominio != null)
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
        internal static TipoServicoDominio converterITipoServicoDominioParaTipoServicoDominio(ITipoServicoDominio tipoServicoDominio)
        {
            TipoServicoDominio _tipoServicoDominio = null;

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
