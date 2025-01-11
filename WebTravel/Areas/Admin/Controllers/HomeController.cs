using Microsoft.AspNetCore.Mvc;
using WebTravel.Utilities;

namespace WebTravel.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {

        [Area("Admin")]
        public IActionResult Index()
        {
           
            return View();
        }
    }
}
