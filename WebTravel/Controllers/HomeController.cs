using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebTravel.Models;

namespace WebTravel.Controllers
{
    public class HomeController : Controller
    {
        private readonly TravelContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(TravelContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
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
