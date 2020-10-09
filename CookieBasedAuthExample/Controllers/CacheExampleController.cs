using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace CookieBasedAuthExample.Controllers
{
    public class CacheExampleController : Controller
    {
        private readonly IMemoryCache _Cache;
        public CacheExampleController(IMemoryCache cache)
        {
            _Cache = cache;
        }
        //[ResponseCache(Duration =0,Location =ResponseCacheLocation.None, NoStore = true)]
        [ResponseCache(CacheProfileName ="NoCaching")]
        public IActionResult Index(int id)
        {
            string value = "";
            if (!_Cache.TryGetValue<string>("Time", out value))
            {
                var cacheoptions = new MemoryCacheEntryOptions();
                cacheoptions.SetPriority(CacheItemPriority.Normal);
                cacheoptions.AbsoluteExpiration = DateTime.Now.AddDays(1);
                value = DateTime.Now.ToLongTimeString();
                _Cache.Set<string>("Time", value, cacheoptions);
            }
            ViewBag.CacheTimeValue = value;
            return View();
        }



        public IActionResult GetEmployees()
        {
            List<Employee> lst = null;
            if (!_Cache.TryGetValue<List<Employee>>("Employess",out lst))
            {
                lst = new List<Employee>();
                lst.Add(new Employee { EmployeeId = 1, EmployeeName = "Schott" });
                lst.Add(new Employee { EmployeeId = 2, EmployeeName = "Sam" });
                _Cache.Set<List<Employee>>("Employess", lst);
            }
            return Json(lst);
        }
    }



    class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}
