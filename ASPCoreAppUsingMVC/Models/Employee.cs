﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreAppUsingMVC.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public double Salary { get; set; }
        public string DeptName { get; set; }
    }



    //public class EmpDto
    //{
    //    public Employee Employee { get; set; }
    //    public Person Person { get; set; }
    //}
}