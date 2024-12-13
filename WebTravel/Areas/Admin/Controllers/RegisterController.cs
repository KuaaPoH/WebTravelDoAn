using Microsoft.AspNetCore.Mvc;
using WebTravel.Models;
using WebTravel.Utilities;
using WebTravel.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace WebTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly TravelContext _context;
        public RegisterController(TravelContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(TbAdminUser user)
        {
            if (user == null)
            {
                return NotFound();
            }
            var check = _context.TbAdminUsers
    .Where(m => m.Email == user.Email)
    .FirstOrDefault();

            if (check != null)
            {
                // Kiểm tra xem email hay username đã tồn tại
              
                    Function._MessageEmail = "Email đã được sử dụng!";
              

                return RedirectToAction("Index", "Register");
            }

            Function._MessageEmail = string.Empty;
            user.Password = Function.MD5Password(user.Password);
            
            _context.Add(user);
            _context.SaveChanges();
           
            return RedirectToAction("Index", "Login");
        }
    }
}