using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServicoOnlineServer.usuario.entidade;
using ServicoOnlineServer.extensao;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServicoOnlineServer.Controllers
{
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public UsuarioController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IEmailSender emailSender,
            ILoggerFactory loggerFactory)
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = loggerFactory.CreateLogger<UsuarioController>();
        }

        [Route("Registrar")]
        [HttpPost(Name = "Registrar")]
        [AllowAnonymous]
        public async Task<IActionResult> Registrar([FromBody] Usuario model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(model, model.PasswordHash);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Usuário criado com nova senha");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(model);
                    var callbackUrl = Url.EmailConfirmarLink(model.Id, code, Request.Scheme);
                    await _emailSender.SendEmailConfirmacaoAsync(model.Email, callbackUrl);

                    await _signInManager.SignInAsync(model, isPersistent: false);
                    _logger.LogInformation("Email de confirmação do usuário criado");
                    return Json("UsuarioId:" + model.Id);
                }
                AddErrors(result);
            }

            return Json(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmarEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction(nameof(ValuesController.Get), "Home");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userId}'.");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetarSenha(ResetSenhaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction(nameof(ResetSenhaViewModel));
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Codigo, model.Senha);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(ResetSenhaViewModel));
            }
            AddErrors(result);
            return Json(model);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> createLogin(string userId,UserLoginInfo userLoginInfo)
        {
            Task<IdentityUser> usuarios = _userManager.FindByIdAsync(userId);
            var _usuario = await usuarios;
            var resultado = await _userManager.AddLoginAsync(_usuario, userLoginInfo);
            if (resultado.Succeeded)
            {
                return RedirectToAction(nameof(ValuesController.Get), "Home");
            }
            AddErrors(resultado);
            return Json(userLoginInfo);
        }

        [Route("adicionarFuncaoAoUsuario")]
        [HttpPost(Name = "adicionarFuncaoAoUsuario")]
        public async Task<bool> adicionarFuncaoAoUsuario(string userId, string roleName)
        {
           
            Task<IdentityUser> usuarios = _userManager.FindByIdAsync(userId);
            var _usuario = await usuarios;
            var resultado = await _userManager.AddToRoleAsync(_usuario, roleName);
            if (resultado.Succeeded)
                return true;

            AddErrors(resultado);
            return false;
        }
        [Route("criarRequisicaoParaUsuario")]
        [HttpPost(Name = "criarRequisicaoParaUsuario")]
        public async Task<bool> criarRequisicaoParaUsuario(string userId, Claim claim)
        {

            Task<IdentityUser> usuarios = _userManager.FindByIdAsync(userId);
            var _usuario = await usuarios;
            var resultado = await _userManager.AddClaimAsync(_usuario, claim);
            if (resultado.Succeeded)
                return true;

            AddErrors(resultado);
            return false;
        }
        [Route("criarRequisicaoParaUsuario")]
        [HttpPost(Name = "criarRequisicaoParaUsuario")]
        public async Task<bool> criarTokenParaUsuario(string usuarioId,string nomeProvedor, string provedorToken,string objetivoToken)
        {
            Task<IdentityUser> usuarios = _userManager.FindByIdAsync(usuarioId);
            IdentityUser _usuario = await usuarios;
            byte[] token = await _userManager.CreateSecurityTokenAsync(_usuario);
            string objetivoDoToken = await _userManager.GenerateUserTokenAsync(_usuario, provedorToken, objetivoToken);
            string twoFactor =  await _userManager.GenerateTwoFactorTokenAsync(_usuario, provedorToken);
            return true;
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
