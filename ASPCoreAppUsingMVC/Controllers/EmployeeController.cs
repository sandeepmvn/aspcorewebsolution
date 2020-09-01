using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreAppUsingMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreAppUsingMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            var emplst = new List<Employee>() {
            new Employee(){
            EmpId=1,
            EmpName="Schott",
             DeptName="Test",
              Salary=250000
            },
             new Employee(){
            EmpId=2,
            EmpName="s1",
             DeptName="Test",
              Salary=250000
            },
              new Employee(){
            EmpId=3,
            EmpName="s2",
             DeptName="Test",
              Salary=250000
            },
            };

            ViewBag.Persons = new List<Person>()
    {
        new Person()
        {
            FirstName="Schott",
            LastName="M"
        }
    };
            return View(emplst);
        }

        //Details

        //create


        public IActionResult Create()
        {
            return View();
        }

        //Edut



        //Delete

    }
}
