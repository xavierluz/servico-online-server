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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServicoOnlineServer.Controllers
{
    [Route("api/Usuario")]
    //[Produces("application/json")]
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
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(model);
                    var callbackUrl = Url.EmailConfirmarLink(model.Id, code, Request.Scheme);
                    await _emailSender.SendEmailConfirmacaoAsync(model.Email, callbackUrl);

                    await _signInManager.SignInAsync(model, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
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
        public async Task<IActionResult> ResetSenha(ResetSenhaViewModel model)
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
            return View();
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
