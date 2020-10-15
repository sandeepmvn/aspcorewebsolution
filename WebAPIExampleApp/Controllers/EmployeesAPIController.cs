using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebAPIExampleApp.Data;
using WebAPIExampleApp.Models;

namespace WebAPIExampleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesAPIController : ControllerBase
    {
        private readonly WebAPIExampleAppContext _context;

        public EmployeesAPIController(WebAPIExampleAppContext context)
        {
            _context = context;
        }

        //[HttpGet("/GetEmp")]
        //public HttpResponseMessage GetEmp()
        //{
        //    var list = new
        //    {
        //        id=1,
        //        name="schott"
        //    };

        //    return new HttpResponseMessage()
        //    {
        //        StatusCode = System.Net.HttpStatusCode.OK,
        //        Content = new StringContent(JsonConvert.SerializeObject(list))
        //    };
        //}


        //public System.Web.Http.IHttpActionResult GetEmps()
        //{
        //    return (System.Web.Http.IHttpActionResult)Ok();
        //}


        //public List<Employee> GetEmployees()
        //{
        //    return _context.Employee.ToList();
        //}

        // GET: api/EmployeesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            return await _context.Employee.ToListAsync();
        }

        // GET: api/EmployeesAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            //return Ok(employee);
            return Ok(employee);
        }

        // PUT: api/EmployeesAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmpId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmployeesAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmpId }, employee);
        }

        // DELETE: api/EmployeesAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmpId == id);
        }
    }
}
