using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIExampleApp.Controllers
{
    
   
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/{v:apiVersion}/EmployeesAPI")]
    public class EmployeesV2Controller : ControllerBase
    {
        // GET: api/<EmployeesV2Controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "valuefrom v2", "value2 from v2" };
        }

        // GET api/<EmployeesV2Controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeesV2Controller>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeesV2Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeesV2Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
