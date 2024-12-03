using WebTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WebTravel.ViewComponents
{
    public class SlideViewComponent : ViewComponent
    {
        private readonly TravelContext _context;
        public SlideViewComponent(TravelContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _context.TbSlides
                .Where(m => (bool)m.IsActive)
            .OrderByDescending(e => e.SlideId)
                .ToListAsync();
            return View(items);
        }
    }
}
