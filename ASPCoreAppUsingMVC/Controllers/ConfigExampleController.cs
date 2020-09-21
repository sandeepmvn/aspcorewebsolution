using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ASPCoreAppUsingMVC.Controllers
{
    public class ConfigExampleController : Controller
    {
        //IConfiguration _configuration;
        //public ConfigExampleController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        IOptions<ConfigSettingData> _settings;
        IWebHostEnvironment _env;
        public ConfigExampleController(IOptions<ConfigSettingData> settings,
            IOptionsSnapshot<ConfigSettingData> settings2,
            IWebHostEnvironment webHostEnvironment)
        {
            _settings = settings;
            _env = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var envName = _env.EnvironmentName;
            //if(envName=="")
            //{

            //}
            //elses
            // var data = _configuration["ConnectionString"];
            // var data1 = _configuration["ConfigSection:ConnectionString"];
            // //pre-defined methods
            // data = _configuration.GetValue<string>("ConnectionString");
            // data1 = _configuration.GetSection("ConfigSection").GetValue<string>("ConnectionString");
            // var arrdata3 = _configuration.GetSection("SecurityConfig").GetValue<List<string>>("JwTDomains");
            // //using classses
            // ConfigSettingData configSettingData = new ConfigSettingData();
            // _configuration.Bind(configSettingData);
            //data1= configSettingData.ConnectionString;
            //using DI
            var connectionstring = _settings.Value.ConnectionString;

            return View();
        }
    }
}
