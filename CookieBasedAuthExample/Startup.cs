using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookieBasedAuthExample.Hubs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CookieBasedAuthExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie().AddFacebook(facebookOptions =>
            {

                facebookOptions.AppId = "962586804253207";
                facebookOptions.AppSecret = "22e9d262321ccc838172485459598e18";

            });
            services.AddControllersWithViews(options=> {

                options.CacheProfiles.Add("NoCaching", new Microsoft.AspNetCore.Mvc.CacheProfile()
                {
                    Duration = 0,
                    Location = Microsoft.AspNetCore.Mvc.ResponseCacheLocation.None,
                    NoStore = true
                });
            });
            services.AddSignalR();
            services.AddMemoryCache();
            services.AddResponseCaching();
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseResponseCaching();

            //app.UseSignalR(options =>
            //{
            //    options.MapHub<ChatHub>("/ChatHub");
            //});

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/ChatHub");

                //endpoints.MapDefaultControllerRoute();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=CacheExample}/{action=Index}/{id?}");
            });
        }
    }
}
