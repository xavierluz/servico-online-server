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
                _tipoServicoDominio.caminhoDaImage = _tipoServicoDominio.caminhoDaImage;
                _tipoServicoDominio.Descricao = _tipoServicoDominio.Descricao;
                _tipoServicoDominio.Id = _tipoServicoDominio.Id;
                _tipoServicoDominio.Nome = _tipoServicoDominio.Nome;
                _tipoServicoDominio.Status = _tipoServicoDominio.Status;
            }

            return _tipoServicoDominio;
        }
    }
}
