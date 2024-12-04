using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTravel.Models;

namespace WebTravel.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly TravelContext _context;
        public BlogViewComponent(TravelContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _context.TbBlogs
                .Where(m => (bool)m.IsActive)
            .OrderByDescending(e => e.BlogId)
                .ToListAsync();
            return View(items);
        }
    }
}


