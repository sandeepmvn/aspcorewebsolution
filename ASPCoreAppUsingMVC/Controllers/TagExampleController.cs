using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreAppUsingMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPCoreAppUsingMVC.Controllers
{
    public class TagExampleController : Controller
    {
        public IActionResult Index()
        {
            List<Department> depts = new List<Department>()
            {
                new Department
                {
                    DeptId=1,
                    DeptName="Test1"
                },
                 new Department
                {
                    DeptId=2,
                    DeptName="Test2"
                }
            };
            var emps = new Employee() { EmpName = "Schott", EmpId = 1, EmpEmailAddress = "Test@gmail.com",DeptName= "Test2" };
            emps.Description = "jasfsa sadkdfasfd asdasa fjasdffsd";
            emps.Departments = new List<SelectListItem>();
            foreach (var item in depts)
            {
                emps.Departments.Add(new SelectListItem
                {
                    Value=item.DeptName,
                    Text=item.DeptName
                });
            }
            return View(emps);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Index(IFormCollection fc)
        {
            return View();
        }
    }
}
