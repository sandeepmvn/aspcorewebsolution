using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreAppUsingMVC.CustomValidations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPCoreAppUsingMVC.Models
{
    public class Employee:IValidatableObject
    {
        public int EmpId { get; set; }

        [Display(Name ="Employee Name")]
        [Required(ErrorMessage ="Employee Name is Required")]
        public string EmpName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public double Salary { get; set; }
        public string DeptName { get; set; }

        [Remote("IsEmployeeAddress", "ValidationExample")]
        public string EmpEmailAddress { get; set; }
        // [DataType(DataType.EmailAddress)]

        [Display(Name = "Employee Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public EmployeeType Type { get; set; }

        [DesignationValidation]
        public string Designation { get; set; }

        [Required]
        [Range(1,10)]
        public int Rating { get; set; }

        public List<SelectListItem> Departments { get; set; }

        public Address ResAddress { get; set; }

        public Address OffAddress { get; set; }

        [FileExtensions(Extensions = "png,jpg,jpeg,gif",ErrorMessage ="")]
        public IFormFile Photo { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            ValidationResult vr=null;

            if (Designation.ToLower() == "senior" && Rating < 5)
                vr = new ValidationResult("Invalid designation based on rating");
            return new List<ValidationResult>() { vr };
           
        }
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
