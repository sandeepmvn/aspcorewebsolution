using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace DefaultCoreApplication.CustomMW
{
    public class LogURLMiddleware
    {
        RequestDelegate _requestDelegate;

        public LogURLMiddleware(RequestDelegate request)
        {
            _requestDelegate = request;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine(context.Request.Path);
            await _requestDelegate.Invoke(context);
        }
    }



    public static class LogURLExtension
    {
        public static void UseLogURL(this IApplicationBuilder app)
        {
            app.UseMiddleware<LogURLMiddleware>();
        }
    }
}
