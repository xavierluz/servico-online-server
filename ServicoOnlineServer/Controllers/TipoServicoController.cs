using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServicoOnlineBusiness.tiposervico;
using ServicoOnlineBusiness.tiposervico.abstracts;
using ServicoOnlineBusiness.tiposervico.dominio.interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServicoOnlineServer.Controllers
{
    [Route("api/[controller]")]
    public class TipoServicoController : Controller
    {
        private TipoServicoFactory servicoFactory = null;
        private IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted;

        public Task<ActionResult<List<ITipoServicoDominio>>> Gets()
        {
            servicoFactory = TipoServicoFactory.Create(this.isolationLevel);
            TipoServicoAbstract tipoServico = servicoFactory.getTipoServico();
            Task<List<ITipoServicoDominio>> tiposServicos = tipoServico.Gets();

            return Json(tiposServicos.Result.ToList());
        }
    }
}
