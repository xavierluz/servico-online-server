using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServicoOnlineBusiness.factory;
using ServicoOnlineBusiness.servico.abstracts;
using ServicoOnlineBusiness.servico.dominio.entidade;
using ServicoOnlineBusiness.servico.dominio.interfaces;
using ServicoOnlineServer.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServicoOnlineServer.Controllers
{
    [Route("api/[controller]")]
    public class ServicoController : Controller
    {
        private ServicoFactory servicoFactory = null;
        private IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted;

        [HttpGet("{tipoServicoId}", Name = "GetServico")]
        public async Task<ActionResult<IEnumerable<ServicoViewModel>>> Gets(int tipoServicoId)
        {
            servicoFactory = ServicoFactory.Create(this.isolationLevel);
            ServicoAbstract Servico = servicoFactory.getServico();
            List<IServicoDominio> Servicos = await Servico.Gets(tipoServicoId);

            return Servicos.ToList().ConvertAll(new Converter<IServicoDominio, ServicoViewModel>(this.converterIServicoDominioParaServicoViewModel));
        }

        private ServicoViewModel converterIServicoDominioParaServicoViewModel(IServicoDominio servicoDominio)
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
    }
}
