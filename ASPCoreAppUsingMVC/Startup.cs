using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreAppUsingMVC.CustomMW;
using ASPCoreAppUsingMVC.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace ASPCoreAppUsingMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //IService Collection ---- DI Container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddTransient<IMyDependencyService, MyDependencyService>();
            services.AddScoped<IMyDependencyService2, MyDependencyService2>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           
            app.UseHttpsRedirection();//Https
            app.UseStaticFiles();
            //app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "wwwroot")),
            //    RequestPath="/files"

            //});
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "demo")),
            //});
           //Metadata of routing
           //it provides you best match of routing
            app.UseRouting();
            app.UseLogURL("Request");
            app.UseAuthorization();


         


            //app.UseStatusCodePages(async context =>
            //{
            //  var code= context.HttpContext.Response.StatusCode;
            //    if(code==404)
            //    {
            //        await context.HttpContext.Response.WriteAsync("Requested URL is not FOund");
            //    }
            //    else if(code==401)
            //    {
            //        await context.HttpContext.Response.WriteAsync("Requested URL is not authorized to access");
            //    }
            //});

            app.UseStatusCodePagesWithRedirects("/home/error");

            app.UseEndpoints(endpoints =>
            {
                //url
                endpoints.MapControllerRoute(name: "PrivacyRoute", pattern: "privacy", defaults: new { controller = "Home", action = "Privacy" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Employee}/{action=Index}/{id?}");
            });
        }
    }
}
