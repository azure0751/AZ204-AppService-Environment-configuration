using appserviceConfig.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace appserviceConfig.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Read environment variable
            var message = Environment.GetEnvironmentVariable("MY_APP_MESSAGE")
                          ?? "⚠ No environment message found :  Set the value for 'MY_APP_MESSAGE' in environment configuration.";

            // Pass to view
            ViewData["EnvMessage"] = message;
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
    }
}
