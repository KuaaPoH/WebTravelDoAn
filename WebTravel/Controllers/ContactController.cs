using Microsoft.AspNetCore.Mvc;
using WebTravel.Models;
using System.Diagnostics;

namespace WebTravel.Controllers
{
    public class ContactController : Controller
    {
        private readonly TravelContext _context;
        public ContactController(TravelContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(string name, string phone, string email, string message)
        {
            try
            {
                TbContact contact = new TbContact
                {
                    Name = name,
                    Phone = phone,
                    Email = email,
                    Message = message,
                    CreatedDate = DateTime.Now
                };

                _context.Add(contact);
                await _context.SaveChangesAsync(); // ← Bắt buộc phải await

                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });
            }
        }

    }
}
