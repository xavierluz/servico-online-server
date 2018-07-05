using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServicoOnlineBusiness.factory;
using ServicoOnlineBusiness.pagamento.dominio.interfaces;
using ServicoOnlineServer.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServicoOnlineServer.Controllers
{
    [Route("api/[controller]")]
    public class PagamentoController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<string> Post([FromBody]PagamentoViewModel pagamento)
        {

            IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted;

            ServicoFactory factory = ServicoFactory.Create(isolationLevel);
            var Pagamento = factory.getPagamento();

            IPagamentoDominio pagamentoDominio = new PagamentoViewModel();

            pagamentoDominio.Descricao = pagamento.Descricao;
            pagamentoDominio.Email = pagamento.Email;
            pagamentoDominio.FormaPagamento = pagamento.FormaPagamento;
            pagamentoDominio.Nome = pagamento.Nome;
            pagamentoDominio.Status = "AT";
            pagamentoDominio.Telefone = pagamento.Telefone;

            foreach(var item in pagamento.PagamentoItemViewModels)
            {
                IPagamentoItemDominio pagamentoItem = new PagamentoItemViewModel();
                pagamentoItem.Quantidade = item.Quantidade;
                pagamentoItem.Status = "AT";
                pagamentoItem.ServicoDominioId = item.ServicoDominioId;
                pagamentoDominio.IPagamentoItemDominios.Add(pagamentoItem);

            }

            var pagamentoRetorno = Pagamento.Incluir(pagamentoDominio).Result;
            pagamentoRetorno.IPagamentoItemDominios = null;
            return Ok(pagamentoRetorno);
        }
    

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
