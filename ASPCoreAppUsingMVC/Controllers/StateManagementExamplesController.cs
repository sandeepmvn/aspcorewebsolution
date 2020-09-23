using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreAppUsingMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace ASPCoreAppUsingMVC.Controllers
{
    public class StateManagementExamplesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string cookieName, string cookievalue, bool chkIsPresistent, IFormCollection fc)
        {
            string data = string.Empty;

            if (fc.ContainsKey("btnSubmit"))
            {
                CookieOptions options = new CookieOptions();
                //Presistent Cookie
                if (chkIsPresistent)
                    options.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append(cookieName, cookievalue, options);
            }
            else if (fc.ContainsKey("btnReadCookies"))
            {
                foreach (var item in Request.Cookies)
                {
                    data += $" {item.Key} = {item.Value} ";
                }
            }
            else if (fc.ContainsKey("btnGet"))
            {
                if (Request.Cookies[cookieName] != null)
                {
                    data = cookieName + " = " + Request.Cookies[cookieName];
                }

            }
            else if (fc.ContainsKey("btnDelete"))
            {
                Response.Cookies.Delete(cookieName);
            }

            ViewBag.CookieData = data;
            return View();
        }


        public IActionResult Login()
        {
            if (Request.Cookies["AuthCookie"] != null)
                return RedirectToAction("AuthorizedPage");
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                if (userProfile.Username == userProfile.Password)
                {
                    //cookie
                    CookieOptions options = new CookieOptions();
                    if (userProfile.RememberMe)
                        options.Expires = DateTime.Now.AddDays(20);

                    Response.Cookies.Append("AuthCookie", userProfile.Username, options);
                    return RedirectToAction("AuthorizedPage");

                }
                ModelState.AddModelError("", "Invalid UserName or Password");
            }
            return View(userProfile);
        }


        public IActionResult AuthorizedPage()
        {
            ViewBag.LoggedUserName = Request.Cookies["AuthCookie"];
            ViewBag.IsAuthorized = Request.Cookies["AuthCookie"] != null;
            return View();
        }

        public IActionResult LogOut()
        {
            Response.Cookies.Delete("AuthCookie");
            return RedirectToAction("Login");
        }



        public IActionResult SessionExampleIndex()
        {
            HttpContext.Session.SetString("c1", "v1");
            HttpContext.Session.SetInt32("c2", 20);
            return View();
        }

        public IActionResult RetriveSessions()
        {
            var value=HttpContext.Session.GetString("c1");

            return Content($"c1 = {value}");
        }
        [HttpPost]
        public IActionResult RemoveSessionExample(string key)
        {
            HttpContext.Session.Remove(key);
            return Content($"session {key} is removed");
        }

        public IActionResult ClearSession()
        {
            HttpContext.Session.Clear();
            return Content("All Session has cleared");
        }

    }
}
