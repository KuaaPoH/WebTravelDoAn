using Microsoft.AspNetCore.Mvc;
using WebTravel.Utilities;

namespace WebTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/file-manager")]
    public class FileManagerController : Controller
    {
        public IActionResult Index()
        {
       
            return View();
        }
    }
}