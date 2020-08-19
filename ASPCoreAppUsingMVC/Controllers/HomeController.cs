using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASPCoreAppUsingMVC.Models;
using System.IO;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Hosting;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ASPCoreAppUsingMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _hostEnvironment = webHostEnvironment;
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
        //200
        //400
        //500
        //300--- redirection
        public IActionResult RedirectResultExample()
        {
            //return Redirect("/Home/Index");
            // return RedirectToAction("Index");

            //using Querystring
            //return Redirect("/Home/SayHello?fn=schott&ln=test");
            //return RedirectToAction("SayHello", new { fn = "Schott", ln = "test" });

            //return RedirectPermanent("/Home/Privacy");-301
            return RedirectToActionPermanent("privacy");
        }


        public IActionResult RedirectToRouteExample()
        {
            //without querystring
            return RedirectToRoute("PrivacyRoute");

            //withquerystring
            //return RedirectToRoute("PrivacyRoute",new { id=0});
        }


        public IActionResult DownloadFile()
        {
            var filepath = _hostEnvironment.ContentRootPath;//Directory.GetCurrentDirectory();
            filepath = Path.Combine(filepath, "Demo", "Text1.txt");
            return PhysicalFile(filepath, "text/txt", "test");
        }
        public IActionResult JsonResultExample()
        {
            Person p = new Person();
            p.FirstName = "Sandeep";
            p.LastName = "Soni";
            return Json(p);
        }


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

        [NonAction]
        public void DoSomething()
        {

        }
    }
}
