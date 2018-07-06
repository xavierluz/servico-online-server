using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ServicoOnlineBusiness.factory;
using ServicoOnlineBusiness.tiposervico.abstracts;
using ServicoOnlineBusiness.tiposervico.dominio.interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServicoOnlineServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoServicoController : Controller
    {
        private ServicoFactory servicoFactory = null;
        private IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted;

        [HttpGet(Name = "GetTipos")]
        public async Task<ActionResult<IEnumerable<ITipoServicoDominio>>> Gets()
        {
            servicoFactory = ServicoFactory.Create(this.isolationLevel);
            TipoServicoAbstract tipoServico = servicoFactory.getTipoServico();
            List<ITipoServicoDominio> tiposServicos = await tipoServico.Gets();

            return tiposServicos.ToList();
        }
        [Produces(typeof(ITipoServicoDominio))]
        [HttpGet("{Id}", Name = "GetTipo")]
        public ActionResult<ITipoServicoDominio> Get(int Id)
        {
            servicoFactory = ServicoFactory.Create(this.isolationLevel);
            TipoServicoAbstract tipoServico = servicoFactory.getTipoServico();
            ITipoServicoDominio tiposServicos = tipoServico.Get(Id);

            return Ok(tiposServicos);
        }
      


       
    }
}
