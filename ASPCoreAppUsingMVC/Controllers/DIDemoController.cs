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
        IMyDependencyService myDependencyService;
        ////Controlller
        public DIDemoController(IMyDependencyService dependencyService,IMyDependencyService2 myDependencyService2)
        {
            myDependencyService = dependencyService;
        }
        public IActionResult Index([FromServices]IMyDependencyService dependencyService)
        {
            dependencyService.IncrementCounter();
            return View(dependencyService.GetCounterValue());
        }

        /* var obj=(TestClass)Activator.CreateInstance(typeof(TestClass));
            TestClass tobj = new TestClass();*/
    }



    public class TestClass
    {
        public int Id { get; set; }
    }
}
