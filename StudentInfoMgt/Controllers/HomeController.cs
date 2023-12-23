using Microsoft.AspNetCore.Mvc;
using StudentInfoMgt.Models;
using System.Diagnostics;

namespace StudentInfoMgt.Controllers
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
            _logger.LogInformation("You access the home page");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
