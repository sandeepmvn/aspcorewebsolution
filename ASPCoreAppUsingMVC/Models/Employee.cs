using System;
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

        public EmployeeType Type { get; set; }
    }

    public class Department
    {
        public string DeptName { get; set; }
        public int DeptId { get; set; }
    }


    public enum EmployeeType
    {
        Trainee = 1,
        Junior = 2,
        Senior = 3
    }




    //public class EmpDto
    //{
    //    public Employee Employee { get; set; }
    //    public Person Person { get; set; }
    //}
}
