using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ASPWebAppIdentityEx2.Models
{
    public class DemoUser:IdentityUser
    {
        [Display(Name ="Name")]
        [StringLength(100)]
        public string FullName { get; set; }

        [Display(Name ="Date Of Birth")]
        public DateTime DOB { get; set; }
    }
}
