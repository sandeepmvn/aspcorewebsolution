using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CookieBasedAuthExample.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Mvc;

namespace CookieBasedAuthExample.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string returnURL)
        {
            ViewBag.ReturnURL = returnURL;
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model,string returnURL)
        {

            if (ModelState.IsValid)
            {
                if (model.UserName == model.Password)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,model.UserName),
                        new Claim(ClaimTypes.Role,"Admin")
                    };

                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "Login");
                    
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    var authproperties = new AuthenticationProperties();
                    authproperties.IssuedUtc = DateTime.UtcNow;
                    authproperties.IsPersistent = model.IsRememberMe;
                    if (model.IsRememberMe)
                    {
                        authproperties.ExpiresUtc = DateTime.UtcNow.AddDays(10);
                    }
                    HttpContext.SignInAsync(principal, authproperties);
                    if (!string.IsNullOrEmpty(returnURL))
                        return Redirect(returnURL);
                    return RedirectToAction("privacy", "Home");
                }
                else
                    ModelState.AddModelError("", "Invalid UserName or Password");
            }

            return View(model);
        }



        public async Task<IActionResult> Logout()
        {
           await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }


        public IActionResult AccessDenied(string returnURL)
        {
            return Content("Access is denied");
        }


        public async Task LoginWithFacebook()
        {
            await HttpContext.ChallengeAsync(FacebookDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = "/Home/Privacy"

            }); ;
        }
    }
}
