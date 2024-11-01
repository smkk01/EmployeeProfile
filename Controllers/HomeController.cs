using EmployeeProfile.Model;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeProfile.Controllers
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
            return View();
        }
            
        public IActionResult Create()
        {
            return View();
                
        }
        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}
