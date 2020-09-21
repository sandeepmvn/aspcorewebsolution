using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ASPCoreAppUsingMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Initlizae Host 
            IHost host = CreateHostBuilder(args).Build();
            //Request and Response
            host.Run();
            //CreateHostBuilder(args).Build().Run();
        }

        //configure server , environment variables,loggerfactory, startups, O.S environmanent variables
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostbuilder = Host.CreateDefaultBuilder(args);
           return hostbuilder.ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                //UseEnvironment("Development")
            });
                
        }

        //return =>
        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
