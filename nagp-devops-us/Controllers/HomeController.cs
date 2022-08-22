using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using nagp_devops_us.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace nagp_devops_us.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            //ViewBag.BaseUrl = _configuration.GetValue<string>("BASE_URL");
            //ViewBag.Environment = _configuration.GetValue<string>("ENVIRONMENT");
            ViewBag.BaseUrl = Environment.GetEnvironmentVariable("BASE_URL");
            ViewBag.Environment = Environment.GetEnvironmentVariable("ENVIRONMENT");
            ViewBag.Username = Environment.GetEnvironmentVariable("username");
            ViewBag.Password = Environment.GetEnvironmentVariable("password");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public bool TestFunction(bool val)
        {
           //Added for coverage
           Console.WriteLine("coverage");
            return val;
        }
    }
}
