using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreAppUsingMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Options;

namespace ASPCoreAppUsingMVC.Controllers
{
    public class HtmlHelperExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection fc)
        {
            return View();
        }


        public IActionResult About()
        {
            return View();
        }



        public IActionResult EmployeeExample()
        {

            //ViewData["Id"] = 1;
            //ViewData["Name"] = "E1";
            //ViewData["Salary"] = 10000;
            //ViewData["IsActive"] = true;
            //ViewData["DeptId"] = 2;
            //ViewData["DateOfJoin"] = DateTime.Now;
            //ViewData["EmailAddress"] = "test@test.com";

            Employee emp = new Employee()
            {
                EmpId = 1,
                EmpName = "Schott",
                Salary = 25000,
                DeptName="D2",
                EmpEmailAddress="test@gmail.com"
            };

            List<Department> depts = new List<Department>();
            depts.Add(new Department() { DeptName = "D1", DeptId = 1 });
            depts.Add(new Department() { DeptName = "D2", DeptId = 2 });
            SelectList items = new SelectList(depts, "DeptId", "DeptId");
            ViewData["DeptId"] = items;
            return View(emp);
        }

        [HttpPost]
        public IActionResult EmployeeExample(IFormCollection fc)
        {
            return View();
        }

        public IActionResult EmployeeTest()
        {
            return View();
        }

    }
}
