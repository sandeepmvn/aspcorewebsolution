using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreAppUsingMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreAppUsingMVC.Controllers
{
    public class ModelBinderExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Index(string[] hobbies,string name)
        //{
        //    string str = "Hobbies of " + name + " are ";
        //    str += string.Join(",", hobbies);
        //    return View((object)str);
        //}

        [HttpPost]
        public IActionResult Index(Person1 person)
        {
            var d = ModelState;
            string str = "Hobbies of " + person.Name + " are ";
            str += string.Join(",", person.Hobbies);
            return View((object)str);
        }



        public IActionResult Employee()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Employee(Employee employee)
        //{
        //    return View(employee);
        //}

        [HttpPost]
        public IActionResult Employee(IFormCollection fc)
        {
            var rescity = fc["ResAddress.City"];
            var resstreet= fc["ResAddress.Street"];
            return View();
        }

    }

    public class Person1
    {
        public List<string> Hobbies { get; set; }
       
        [Required]
        public string Name { get; set; }
    }
}
