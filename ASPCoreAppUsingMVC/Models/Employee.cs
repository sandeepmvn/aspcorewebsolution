using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPCoreAppUsingMVC.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        //[DataType(DataType.Password)]
        [Required]
        public string EmpName { get; set; }
        public double Salary { get; set; }
        public string DeptName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmpEmailAddress { get; set; }

        public string Description { get; set; }
        public EmployeeType Type { get; set; }

        public List<SelectListItem> Departments { get; set; }

        public Address ResAddress { get; set; }

        public Address OffAddress { get; set; }
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


    public class Address
    {
        public string Street
        { get; set; }
        public string City { get; set; }

    }




    //public class EmpDto
    //{
    //    public Employee Employee { get; set; }
    //    public Person Person { get; set; }
    //}
}
