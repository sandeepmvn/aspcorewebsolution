using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using ASPCoreAppUsingMVC.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ASPCoreAppUsingMVC.CustomMW
{
    public class LogURLMiddleware
    {
        RequestDelegate _requestDelegate;
        string _info;

        public LogURLMiddleware(RequestDelegate request, string info)
        {
            Console.WriteLine("Middleware");
            _requestDelegate = request;
            _info = info
;
        }

        public async Task InvokeAsync(HttpContext context,ILogger<LogURLMiddleware> logger, IMyDependencyService myDependencyService)
        {
            logger.LogInformation(_info + " :" + context.Request.Path);
            // Console.WriteLine(_info + " :" + context.Request.Path);
            await _requestDelegate.Invoke(context);
        }
    }



    public static class LogURLExtension
    {
        public static void UseLogURL(this IApplicationBuilder app, string info)
        {
            app.UseMiddleware<LogURLMiddleware>(info);
        }
    }
}
