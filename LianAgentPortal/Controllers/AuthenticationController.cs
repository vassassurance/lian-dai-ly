using LianAgentPortal.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System;
using LianAgentPortal.Models.DbModels;
using LianAgentPortal.Commons.Constants;
using LianAgentPortal.Models.ViewModels.Authentication;
using Google.Authenticator;

namespace LianAgentPortal.Controllers
{
    [Authorize]
    public class AuthenticationController : Controller
    {
        private readonly UserManager<LianUser> _userManager;
        private readonly SignInManager<LianUser> _signInManager;
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;

        public AuthenticationController(
            SignInManager<LianUser> signInManager,
            UserManager<LianUser> userManager,
            ApplicationDbContext db,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            _configuration = configuration;
        }

        [AllowAnonymous]
        public IActionResult SignIn()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model, string? returnUrl)
        {
            returnUrl ??= Url.Content("~/");

            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                //if (user != null && user.IsActivated)
                //{
                //    var validateTfa = ValidateTwoFactorPIN(model.Pin, user.GoogleAuthenticatorSecretCode);
                //    if (!validateTfa)
                //    {
                //        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                //        return View(model);
                //    }
                //}
                //else
                //{
                //    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                //    return View(model);
                //}


                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index", "DashBoard");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

			if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("SignIn");
            }
        }

        public async Task<IActionResult> ChangePassword()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var checkOldPass = await _userManager.CheckPasswordAsync(user, model.OldPassword);
            if (!checkOldPass)
            {
                ModelState.AddModelError("OldPassword", "Password Hiện Tại Không Đúng");
                return View(model);
            }

            //var passHash = new PasswordHasher<LianUser>();

            if (user != null)
            {
                var removePassword = this._userManager.RemovePasswordAsync(user);
                removePassword.Wait();
                if (removePassword.Result.Succeeded)
                {
                    //user.PasswordHash = passHash.HashPassword(user, model.NewPassword);
                    var addPassword = _userManager.AddPasswordAsync(user, model.NewPassword);
                    addPassword.Wait();
                    if (addPassword.Result.Succeeded)
                    {
                        _db.SaveChanges();
                        TempData[TempDataConstants.TEMP_DATA_INFO_MESSAGE] = "Đổi password Thành Công";
                        return RedirectToAction("ChangePassword");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Không đặt được password mới");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Không xóa được pass cũ");
                }
            }
            else
            {
                ModelState.AddModelError("", "Không tìm thấy user");
            }
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        #region helpers

        private bool ValidateTwoFactorPIN(string pin, string code)
        {
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            return tfa.ValidateTwoFactorPIN(code, pin);
        }

        #endregion
    }
}
