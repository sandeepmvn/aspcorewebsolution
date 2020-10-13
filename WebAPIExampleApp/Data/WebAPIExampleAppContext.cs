using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIExampleApp.Models;

namespace WebAPIExampleApp.Data
{
    public class WebAPIExampleAppContext : DbContext
    {
        public WebAPIExampleAppContext (DbContextOptions<WebAPIExampleAppContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPIExampleApp.Models.Employee> Employee { get; set; }
    }
}
