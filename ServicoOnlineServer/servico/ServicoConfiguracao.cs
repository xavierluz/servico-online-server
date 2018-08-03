using ServicoOnlineBusiness.servico.dominio.interfaces;
using ServicoOnlineServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoOnlineServer.servico
{
    internal class ServicoConfiguracao
    {
        internal static ServicoViewModel converterIServicoDominioParaServicoViewModel(IServicoDominio servicoDominio)
        {
            ServicoViewModel _servicoDominio = null;
            if (servicoDominio != null)
            {
                _servicoDominio = new ServicoViewModel();

                _servicoDominio.Descricao = servicoDominio.Descricao;
                _servicoDominio.Id = servicoDominio.Id;
                _servicoDominio.Indicacao = servicoDominio.Indicacao;
                _servicoDominio.Nome = servicoDominio.Nome;
                _servicoDominio.Preco = servicoDominio.Preco;
                _servicoDominio.Status = servicoDominio.Status;
                _servicoDominio.TipoServicoCaminhoDaImage = servicoDominio.ITipoServico.caminhoDaImage;
                _servicoDominio.tipoServicoDominioId = servicoDominio.tipoServicoDominioId;
                _servicoDominio.TipoServicoNome = servicoDominio.ITipoServico.Nome;
            }

            return _servicoDominio;
        }
        internal static IServicoDominio converterServicoViewModelParaIServicoDominio(ServicoViewModel servicoViewModel)
        {
            IServicoDominio _servicoDominio = null;
            if (servicoViewModel != null)
            {
                _servicoDominio = new ServicoViewModel();

                _servicoDominio.Descricao = servicoViewModel.Descricao;
                _servicoDominio.Id = servicoViewModel.Id;
                _servicoDominio.Indicacao = servicoViewModel.Indicacao;
                _servicoDominio.Nome = servicoViewModel.Nome;
                _servicoDominio.Preco = servicoViewModel.Preco;
                _servicoDominio.Status = servicoViewModel.Status;
                _servicoDominio.ITipoServico = servicoViewModel.ITipoServico;
                _servicoDominio.tipoServicoDominioId = servicoViewModel.tipoServicoDominioId;
   
            }

            return _servicoDominio;
        }
    }
}
