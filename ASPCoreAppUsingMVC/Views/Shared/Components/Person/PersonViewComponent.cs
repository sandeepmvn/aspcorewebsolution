using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreAppUsingMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreAppUsingMVC.Views.Shared.Component.Person
{
    public class PersonViewComponent:ViewComponent
    {
        public PersonViewComponent()
        {
            //Inject
            //db class
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var persons = new List<ASPCoreAppUsingMVC.Models.Person>()
            {
                new ASPCoreAppUsingMVC.Models.Person()
                {
                     FirstName="Schott",
                     LastName="R"
                },
                new ASPCoreAppUsingMVC.Models.Person()
                {
                     FirstName="FirstName 1",
                     LastName="LastName"
                }
            };

            return View(persons);
        }

    }

}
