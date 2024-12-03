using WebTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WebTravel.ViewComponents
{
    public class TourViewComponent : ViewComponent
    {
        private readonly TravelContext _context;
        public TourViewComponent(TravelContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _context.TbTours
                .Where(m => (bool)m.IsActive)
            .OrderByDescending(e => e.TourId)
                .ToListAsync();
            return View(items);
        }
    }
}
