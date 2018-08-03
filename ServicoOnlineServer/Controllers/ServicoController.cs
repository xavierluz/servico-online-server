using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicoOnlineBusiness.factory;
using ServicoOnlineBusiness.servico.abstracts;
using ServicoOnlineBusiness.servico.dominio.entidade;
using ServicoOnlineBusiness.servico.dominio.interfaces;
using ServicoOnlineServer.servico;
using ServicoOnlineServer.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServicoOnlineServer.Controllers
{
    [Route("api/Servico")]
    public class ServicoController : Controller
    {
        private ServicoFactory servicoFactory = null;
        private IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted;

        [Route("Create")]
        [HttpPost(Name = "Create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] ServicoViewModel model)
        {
            servicoFactory = ServicoFactory.Create(this.isolationLevel);
            ServicoAbstract Servico = servicoFactory.getServico();
            IServicoDominio servicoDominio = ServicoConfiguracao.converterServicoViewModelParaIServicoDominio(model);
            var resultado = await Servico.Incluir(servicoDominio);
            return Json(resultado.Succeeded);
           
        }

        [HttpGet("{tipoServicoId}", Name = "GetServico")]
        public async Task<ActionResult<IEnumerable<ServicoViewModel>>> Gets(int tipoServicoId)
        {
            servicoFactory = ServicoFactory.Create(this.isolationLevel);
            ServicoAbstract Servico = servicoFactory.getServico();
            List<IServicoDominio> Servicos = await Servico.Gets(tipoServicoId);

            return Json(Servicos.ToList().ConvertAll(new Converter<IServicoDominio, ServicoViewModel>(ServicoConfiguracao.converterIServicoDominioParaServicoViewModel)));
        }

        
    }
}
