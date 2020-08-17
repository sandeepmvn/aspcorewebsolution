using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASPCoreAppUsingMVC.Models;

namespace ASPCoreAppUsingMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        //Primitive 
        //IActionResut------ web /web spect-----/Html // ViewResult--- Return Html Content
        public IActionResult SayHello(string fn, string ln)
        {
            if (string.IsNullOrEmpty(fn) || string.IsNullOrEmpty(ln))
                return BadRequest();

            Person person = new Person()
            {
                FirstName = fn,
                LastName = ln
            };
           //return View((object)"");
          // return View(model:"");
            return View(person);
        }

        public IActionResult ContentResultExample()
        {
            return Content("<Person><FirstName>Schott</FirstName> <LastName>test</LastName></Person>");
        }

        //Redirect /{controller}/{action}  ---302
        //RedirectToAction (controllerName,actionName)--- 302
        //RedirectToPermenant---  301---- OfferPage (SEO)------Offerpage1
        //ReddirectToActionPermenant----- 301



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
