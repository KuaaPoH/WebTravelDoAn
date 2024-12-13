using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTravel.Models;

namespace WebTravel.ViewComponents
{
    public class OurTravelGuides : ViewComponent
    {
        private readonly TravelContext _context;
        public OurTravelGuides(TravelContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _context.TbAccounts
                .Where(m => (bool)m.IsActive)
            .OrderByDescending(e => e.AccountId)
                .ToListAsync();
            return View(items);
        }
    }
}


