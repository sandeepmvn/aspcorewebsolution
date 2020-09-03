using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreAppUsingMVC.Controllers
{
    public class HtmlHelperExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection fc)
        {
            return View();
        }


        public IActionResult About()
        {
            return View();
        }
    }
}
