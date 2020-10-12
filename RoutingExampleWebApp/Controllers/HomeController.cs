using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;
using Microsoft.Extensions.Logging;
using RoutingExampleWebApp.Models;

namespace RoutingExampleWebApp.Controllers
{
   // [Route("Home")]
   [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Route("",Name ="defaultAttributeRouting")]
        [Route("[action]")]
        [Route("[action]/{id:range(0,100):required}")]
        public IActionResult Index(int id)
        {
            return View();
        }

        [Route("aboutPrivacy")]
        public IActionResult Privacy()
        {
            //var data = ControllerContext.MyDisplayRouteInfo();
            //return data;
            return RedirectToRoute("defaultAttributeRouting");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
