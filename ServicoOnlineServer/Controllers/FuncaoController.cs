using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServicoOnlineServer.perfil.funcao;
using ServicoOnlineServer.ViewModels;
using ServicoOnlineUsuario.bases.banco.interfaces;
using ServicoOnlineUsuario.bases.banco.sqlServer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServicoOnlineServer.Controllers
{
    [Route("api/Funcao")]
    public class FuncaoController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public FuncaoController(UserManager<IdentityUser> userManager,
           RoleManager<IdentityRole> roleManager,
            IEmailSender emailSender,
            ILoggerFactory loggerFactory)
        {

            _userManager = userManager;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _logger = loggerFactory.CreateLogger<UsuarioController>();
        }

        [Route("createFuncao")]
        [HttpPost(Name = "createFuncao")]
        public async Task<IActionResult> createFuncao([FromBody] IdentityRole model)
        {
            model.Id = Guid.NewGuid().ToString();
            if (ModelState.IsValid)
            {

                var result = await _roleManager.CreateAsync(model);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Normalizando o função(role)");
                     await _roleManager.UpdateNormalizedRoleNameAsync(model);
                    _logger.LogInformation("Normalização realizada com sucesso");
                    return Json(model);
                }
                AddErrors(result);
            }

            return Json(model);
        }
        // POST api/<Empresa>
        [Route("getsFuncao")]
        [HttpPost(Name = "getsFuncao")]
        public async Task<ActionResult<IEnumerable<IdentityRole>>> Gets([FromBody] DataTablesResponseViewModel model)
        {
            string filtro = model.Search.Value;
            int ordernar = model.Order[0].Column;
            string ordernarDirecao = model.Order[0].Dir;

            int _draw = model.Draw;
            int startRec = model.Start;
            int pageSize = model.Length;

            FuncaoManager funcaoManager = FuncaoManager.Create(_roleManager);

            IList<IdentityRole> funcoes = await funcaoManager.Gets(startRec, filtro, pageSize);

            //IList<EmpresaTableViewModel> tablesEempresa = converterEmpresaViewModelParaEmpresaTableViewModel(empresas);
            List<IdentityRole> funcoesOrdenadas = FuncaoConfiguracao.ordenacaoTableFuncoes(ordernar, ordernarDirecao, funcoes);

            int totalRegistros = funcaoManager.totalRegistro;

            var retorno = this.Json(new { draw = _draw, recordsTotal = totalRegistros, recordsFiltered = totalRegistros, data = funcoesOrdenadas });

            return retorno;
        }

        //public IList<EmpresaTableViewModel> converterEmpresaViewModelParaEmpresaTableViewModel(IList<IEmpresa> empresas)
        //{

        //    IList<EmpresaTableViewModel> tableEmpresa = new List<EmpresaTableViewModel>();

        //    foreach (var _empresa in empresas)
        //    {
        //        EmpresaTableViewModel _tableEmpresa = new EmpresaTableViewModel();
        //        _tableEmpresa.CnpjCpf = _empresa.CnpjCpf;
        //        _tableEmpresa.Email = _empresa.Email;
        //        _tableEmpresa.Id = _empresa.Id.ToString();
        //        _tableEmpresa.Nome = _empresa.Nome;
        //        _tableEmpresa.NomeFantasia = _empresa.NomeFantasia;
        //        _tableEmpresa.Status = _empresa.Status;
        //        tableEmpresa.Add(_tableEmpresa);
        //        _tableEmpresa = null;
        //    }

        //    return tableEmpresa;
        //}

        // POST api/<Empresa>
        [Route("getsFuncaoRequisicao")]
        [HttpPost(Name = "getsFuncaoRequisicao")]
        public async Task<ActionResult<IEnumerable<RequisicaoTableViewModel>>> getsRequisicoes([FromBody] DataTablesResponseViewModel model)
        {
            string filtro = model.Search.Value;
            int ordernar = model.Order[0].Column;
            string ordernarDirecao = model.Order[0].Dir;

            int _draw = model.Draw;
            int startRec = model.Start;
            int pageSize = model.Length;
            IsolationLevel _isolationLevel = IsolationLevel.ReadUncommitted;
            ISqlBase sqlBase = SqlServerFactory.Create();
            FuncaoManager funcaoManager = FuncaoManager.Create(sqlBase, _isolationLevel);

            List<IdentityRoleClaim<string>> funcoesRequisicoes = await funcaoManager.getsRequisicoes(model.empresaUsuarioFuncao.FuncaoId, startRec, filtro, pageSize);

            IList<RequisicaoTableViewModel> tableFuncaoRequisicao = funcoesRequisicoes.ConvertAll(new Converter<IdentityRoleClaim<string>, RequisicaoTableViewModel>(FuncaoConverter.converterIdentityRoleClaimParaClaim));

            IList<RequisicaoTableViewModel> funcoesRequisicoesOrdenadas = FuncaoConfiguracao.ordenacaoTableFuncoesRequisicoes(ordernar, ordernarDirecao, tableFuncaoRequisicao);

            int totalRegistros = funcaoManager.totalRegistro;

            var retorno = this.Json(new { draw = _draw, recordsTotal = totalRegistros, recordsFiltered = totalRegistros, data = funcoesRequisicoesOrdenadas });

            return retorno;
        }
        [Route("adicionarRequisicaoAfuncao")]
        [HttpPost(Name = "adicionarRequisicaoAfuncao")]
        public async Task<bool> adicionarRequisicaoAfuncao([FromBody] ClaimViewModel _funcaoRequisicao)
        {

            Task<IdentityRole> funcao = _roleManager.FindByIdAsync(_funcaoRequisicao.EmpresaUsuario.FuncaoId);
            IdentityRole _funcao = await funcao;

            var resultado = await _roleManager.AddClaimAsync(_funcao, _funcaoRequisicao.toClaim());
            return resultado.Succeeded;
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(ValuesController.Get), "Home");
            }
        }

        #endregion
    }
}
