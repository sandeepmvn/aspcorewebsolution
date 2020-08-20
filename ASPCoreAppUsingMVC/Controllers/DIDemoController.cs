using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreAppUsingMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreAppUsingMVC.Controllers
{
    public class DIDemoController : Controller
    {
        //IMyDependencyService myDependencyService;
        ////Controlller
        //public DIDemoController(IMyDependencyService dependencyService)
        //{
        //    myDependencyService = dependencyService;
        //}
        public IActionResult Index([FromServices]IMyDependencyService dependencyService)
        {
            dependencyService.IncrementCounter();
            return View(dependencyService.GetCounterValue());
        }
      
    }
}
