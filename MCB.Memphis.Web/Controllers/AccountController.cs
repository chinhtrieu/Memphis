using MCB.MasterPiece.Site.AdminSite;
using MCB.Memphis.Core.Services;
using MCB.Memphis.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MCB.Memphis.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAdminUserService _adminUserService;
        public AccountController(IAdminUserService adminUserService)
        {
            _adminUserService = adminUserService;
        }
        public ActionResult Login(string returnUrl)
        {
            var model = new AccountLoginModel { ReturnUrl = returnUrl };
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Login(AccountLoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(model.ReturnUrl)) model.ReturnUrl = Url.Content("~/");

                // Clear the existing external cookie
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);


                // *** !!! This is where you would validate the user !!! ***
                // In this example we just log the user in
                // (Always log the user in for this demo)
                var adminUser = _adminUserService.CheckUserLoginWithHash(SiteAdminTypeEnum.Accumolo, model.UserName, model.Password);
                if (adminUser == null)
                {
                    adminUser = _adminUserService.CheckUserLogin(SiteAdminTypeEnum.Accumolo, model.UserName, model.Password);
                }
                if (adminUser != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, adminUser.UserFullName),
                        new Claim("UserGuid", adminUser.UserGuid.ToString()),
                        new Claim("MyAccumoloLastSiteGuid", adminUser.MyAccumoloLastSiteGuid.ToString()),
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        RedirectUri = Request.Host.Value,
                        
                    };
                    try
                    {
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                    }
                    catch (Exception ex)
                    {
                        model.Errors = new List<string> { ex.Message };
                    }
                }
                else
                {
                    model.Errors = new List<string> { "Incorrect user name or password." };
                }
                
            }
            if (model.Errors?.Any() == true) return View(model);
            return LocalRedirect(model.ReturnUrl);
        }

        public async Task<ActionResult> Logout()
        {
            try
            {
                // Clear the existing external cookie
                await HttpContext
                    .SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch { }

            return Redirect("/Account/Login");
        }
    }
}
