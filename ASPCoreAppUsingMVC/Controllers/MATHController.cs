using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreAppUsingMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreAppUsingMVC.Controllers
{
    public class MATHController : Controller
    {
        // GET: MATHController
       /// [ActionName("Add")]
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public IActionResult Index(int n1, int n2)
        {
            return View(n1 + n2);
        }

    }
}
