using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DefaultCoreApplication.CustomMW;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DefaultCoreApplication
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ///inline -- Middleware--

            //app.UseMiddleware<LogURLMiddleware>();

            //Extension method

            app.UseLogURL();

            //app.Map("/welcome", (builder) =>
            //{
            //    //use
            //    builder.Use(async (context, next) => {
            //      await  context.Response.WriteAsync("From Map Pipeline");
            //    });

            //    //Run

            //});

            //app.Use(async (context, next) =>
            //{
            //    await next.Invoke();
            //});


            //app.Run(async (context) =>
            //{

            //    await context.Response.WriteAsync("Run middleware");
            //});

            //app.Use(async (context, next) =>
            //{

            //    logger.LogInformation("mw2");
            //    next.Invoke();
            //});

        }


        public void Action1(IApplicationBuilder app)
        {

        }

        //private Task customhandler(HttpContext context)
        //{
        //    throw new NotImplementedException();
        //}


        //private async Task(HttpContext context,Func<Task> next)
        //{

        //}

        //private async Task CustomHandler(HttpContext context)
        //{
        //    throw new NotImplementedException();
        //}

        /* app.Use(async (context, next) => {
                logger.LogInformation("Request middleware 1");
                if(context.Request.GetEncodedUrl().Contains(".html"))
                    //log
                      else
                await next.Invoke();
                logger.LogInformation("Response Middleware 1");
            });

            //inline --- middle----  Terminate
            app.Run(async (context) => {
                logger.LogInformation("Request middleware 2");
                context.Response.WriteAsync("Hello World");
                logger.LogInformation("Response Middleware 2");
            });
        */

        /* app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });*/
    }
}
