using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreAppUsingMVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ASPCoreAppUsingMVC.Controllers
{
    public class ModelBinderExampleController : Controller
    {
        IWebHostEnvironment _HostEnvironment;
        public ModelBinderExampleController(IWebHostEnvironment webHostEnvironment)
        {
            _HostEnvironment = webHostEnvironment;
        }
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
        public IActionResult Employee(IFormCollection fc,List<IFormFile> photo)
        {
            //var rescity = fc["ResAddress.City"];
            //var resstreet= fc["ResAddress.Street"];
            //var path = Path.Combine(_HostEnvironment.WebRootPath);
            foreach (var item in photo)
            {
               //if(item.ContentType=="" && item.)
                var file = new FileInfo(item.FileName);
                var filePath = Path.Combine(_HostEnvironment.WebRootPath,"images", file.Name);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    item.CopyTo(fileStream);
                }
            }
            return View();
        }


        public IActionResult AboutUs([BindRequired]int id)
        {
            var d = ModelState;
            return Content("The about us action method");
        }


        public IActionResult EmpExample()
        {
            return View();
        }

        //[Bind("EmpId,EmpName")]
        //[HttpPost]
        //public IActionResult EmpExample(Employee employee, [Bind(Prefix = "ResAddress")]Address resaress)
        //{
        //    return View();
        // }

        [HttpPost]
        public IActionResult EmpExample(IFormCollection fc,int empId)
        {
            Employee emp = GetEmployee(empId);
                //save state
            var data=TryUpdateModelAsync<Employee>(emp);
            return View();
        }



        private Employee GetEmployee(int id)
        {
            return new Employee()
            {
                EmpId = 1,
                EmpEmailAddress = "",
                EmpName = ""
            };
        }

    }

    public class Person1
    {
        public List<string> Hobbies { get; set; }
       
        [Required]
        public string Name { get; set; }
    }
}
