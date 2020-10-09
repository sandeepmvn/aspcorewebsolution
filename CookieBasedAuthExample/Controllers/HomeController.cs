using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CookieBasedAuthExample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using CookieBasedAuthExample.Hubs;

namespace CookieBasedAuthExample.Controllers
{
    //(Roles ="User,Admin")

    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IHubContext<ChatHub> _hubcontext;
        public HomeController(ILogger<HomeController> logger,IHubContext<ChatHub> hubContext)
        {
            _logger = logger;
            _hubcontext = hubContext;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            _hubcontext.Clients.All.SendAsync("ReceiveMessage", "", "Welcome to Asp.Net Web Page");
            return View();
        }

        // [Authorize(Roles ="User,Admin")]
        public IActionResult Privacy()
        {
            var data = User.Claims.ToList();
            return View();
        }


        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [AllowAnonymous]
        [ResponseCache(CacheProfileName = "NoCaching")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
