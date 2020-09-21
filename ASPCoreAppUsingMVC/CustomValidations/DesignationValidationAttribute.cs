using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreAppUsingMVC.CustomValidations
{
    public class DesignationValidationAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null)
                return new ValidationResult("Designation value is Required");
            if(string.IsNullOrWhiteSpace(value.ToString()))
                return new ValidationResult("Designation cannot be null or white space");
            if(!value.ToString().Equals("senior", StringComparison.OrdinalIgnoreCase) && !value.ToString().Equals("junior", StringComparison.OrdinalIgnoreCase))
                return new ValidationResult("Designation can be either senior or junior only");
            return ValidationResult.Success;
        }
    }
}
