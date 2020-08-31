using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreAppUsingMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreAppUsingMVC.Controllers
{
    public class RazorExampleController : Controller
    {
        public IActionResult Index(int fromtable=1, int totable=10)
        {
            ViewBag.LayoutEnv = "Development";
            return View("test",new TableModel {FromTable=fromtable,ToTable=totable });
        }


        public IActionResult RenderTablePartial(int numbertoprint=10)
        {
            return PartialView("_RenderTable", numbertoprint);
        }
    }
}
