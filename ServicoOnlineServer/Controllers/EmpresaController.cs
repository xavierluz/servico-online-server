using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServicoOnlineServer.ViewModels;
using ServicoOnlineUsuario;
using ServicoOnlineUsuario.empresa.dominio.interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServicoOnlineServer.Controllers
{
    [Produces("application/json")]
    [Route("api/Empresa")]
    public class EmpresaController : Controller
    {
        // POST api/<Empresa>
        [Route("CreateEmpresa")]
        [HttpPost(Name = "CreateEmpresa")]
        public async Task<ActionResult<string>> Post([FromBody]EmpresaViewModel empresa)
        {
            if (ModelState.IsValid)
            {
                IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted;

                Services<IEmpresa> services = Services<IEmpresa>.Create(FactoryServices.Create(isolationLevel).getEmpresa());
                empresa.Status = "AT";
                IEmpresa _empresa = await services.IncluirAsync(empresa);
                return Json(_empresa.Id.ToString());
            }
            return Json(empresa);
        }
        // POST api/<Empresa>
        [Route("Gets")]
        [HttpPost(Name = "Gets")]
        public ActionResult<IEnumerable<IEmpresa>> Gets([FromBody] DataTablesResponseViewModel model)
        {
            string filtro = model.Search.Value;
            int ordernar = model.Order[0].Column;
            string ordernarDirecao = model.Order[0].Dir;

            int _draw = model.Draw;
            int startRec = model.Start;
            int pageSize = model.Length;

            IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted;

            Services<IEmpresa> services = Services<IEmpresa>.Create(FactoryServices.Create(isolationLevel).getEmpresa());
            IList<IEmpresa> empresas = services.Gets(startRec, filtro, pageSize);

            IList<EmpresaTableViewModel> tablesEempresa = converterEmpresaViewModelParaEmpresaTableViewModel(empresas);
            List<EmpresaTableViewModel> empresasOrdenadas = ordenacaoTableEmpresa(ordernar, ordernarDirecao, tablesEempresa);

            int totalRegistros = services.totalDeRegistros;

           var retorno = this.Json(new { draw = _draw, recordsTotal = totalRegistros, recordsFiltered = totalRegistros, data = empresasOrdenadas });

            return retorno;
        }

        public IList<EmpresaTableViewModel> converterEmpresaViewModelParaEmpresaTableViewModel(IList<IEmpresa> empresas)
        {

            IList<EmpresaTableViewModel> tableEmpresa = new List<EmpresaTableViewModel>();

            foreach (var _empresa in empresas)
            {
                EmpresaTableViewModel _tableEmpresa = new EmpresaTableViewModel();
                _tableEmpresa.CnpjCpf = _empresa.CnpjCpf;
                _tableEmpresa.Email = _empresa.Email;
                _tableEmpresa.Id = _empresa.Id.ToString();
                _tableEmpresa.Nome = _empresa.Nome;
                _tableEmpresa.NomeFantasia = _empresa.NomeFantasia;
                _tableEmpresa.Status = _empresa.Status;
                tableEmpresa.Add(_tableEmpresa);
                _tableEmpresa = null;
            }

            return tableEmpresa;
        }
        public static List<EmpresaTableViewModel> ordenacaoTableEmpresa(int ordenacao, string ordenacaoAscDesc, IList<EmpresaTableViewModel> tableEmpresa)
        {
            List<EmpresaTableViewModel> _tableEmpresa = new List<EmpresaTableViewModel>();

            try
            {
                // Sorting
                switch (ordenacao)
                {
                    case 0:
                        _tableEmpresa = ordenacaoAscDesc.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? tableEmpresa.OrderByDescending(p => p.CnpjCpf).ToList() : tableEmpresa.OrderBy(p => p.CnpjCpf).ToList();
                        break;
                    case 1:
                        _tableEmpresa = ordenacaoAscDesc.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? tableEmpresa.OrderByDescending(p => p.Nome).ToList() : tableEmpresa.OrderBy(p => p.Nome).ToList();
                        break;
                    case 2:
                        _tableEmpresa = ordenacaoAscDesc.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? tableEmpresa.OrderByDescending(p => p.NomeFantasia).ToList() : tableEmpresa.OrderBy(p => p.NomeFantasia).ToList();
                        break;
                    case 3:
                        _tableEmpresa = ordenacaoAscDesc.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? tableEmpresa.OrderByDescending(p => p.Email).ToList() : tableEmpresa.OrderBy(p => p.Email).ToList();
                        break;
                    case 4:
                        _tableEmpresa = ordenacaoAscDesc.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? tableEmpresa.OrderByDescending(p => p.Status).ToList() : tableEmpresa.OrderBy(p => p.Status).ToList();
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return _tableEmpresa;
        }

    }
}
