﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Create(string name, string phone, string email, string message)
        {
            try
            {
                TbContact contact = new TbContact();
                contact.Name = name;
                contact.Phone = phone;
                contact.Email = email;
                contact.Message = message;
                contact.CreatedDate = DateTime.Now;
                _context.Add(contact);
                _context.SaveChangesAsync();

                return Json(new { status = true });

            }
            catch
            {
                return Json(new { status = false });
            }
        }
    }
}
