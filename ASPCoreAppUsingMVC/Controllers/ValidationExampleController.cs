using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreAppUsingMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreAppUsingMVC.Controllers
{
    public class ValidationExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Employee employee)
        {
            if(ModelState.IsValid)
            {
                //database logic
            }
            return View(employee);
        }


        public IActionResult IsEmployeeAddress(string empEmailAddress)
        {
            if(!string.IsNullOrEmpty(empEmailAddress))
            {
                if (empEmailAddress == "Test@gmail.com")
                    return Json($"{empEmailAddress} is not available");
            }
            return Json(true);
        }
    }
}
