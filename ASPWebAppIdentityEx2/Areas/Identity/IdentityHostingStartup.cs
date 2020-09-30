using System;
using ASPWebAppIdentityEx2.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ASPWebAppIdentityEx2.Areas.Identity.IdentityHostingStartup))]
namespace ASPWebAppIdentityEx2.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ASPWebAppIdentityEx2Context>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ASPWebAppIdentityEx2ContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ASPWebAppIdentityEx2Context>();
            });
        }
    }
}