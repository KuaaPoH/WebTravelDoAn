using Microsoft.AspNetCore.Mvc;
using WebTravel.Models;
using WebTravel.Utilities;
using WebTravel.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace WebTravel.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class LoginController : Controller
    {

        private readonly TravelContext _context;
        public LoginController(TravelContext context)
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
            string pw = Function.MD5Password(user.Password);
            var check = _context.TbAdminUsers.Where(m => (m.Email == user.Email) && (m.Password == pw)).FirstOrDefault();
            if (check == null)
            {
                Function._Message = "Lỗi Tên Đăng Nhập hoặc Mật Khẩu";
                return RedirectToAction("Index", "Login");

            }
            Function._Message = string.Empty;
            Function._UserID = check.UserID;
            Function._Username = string.IsNullOrEmpty(check.UserName) ? string.Empty : check.UserName;
            Function._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;



            return RedirectToAction("Index", "Home");
        }

        }


    
}