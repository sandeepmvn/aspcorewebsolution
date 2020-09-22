using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
            else if(fc.ContainsKey("btnReadCookies"))
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
                   data = cookieName +" = "+Request.Cookies[cookieName];
                }

            }
            else if(fc.ContainsKey("btnDelete"))
            {
                Response.Cookies.Delete(cookieName);
            }

            ViewBag.CookieData = data;
            return View();
        }
    }
}
