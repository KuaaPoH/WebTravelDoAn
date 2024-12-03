using Microsoft.AspNetCore.Mvc;
using WebTravel.Models;

namespace WebTravel.ViewComponents
{
    public class MenuTopViewComponent : ViewComponent
    {
        private readonly TravelContext _context;

        public MenuTopViewComponent(TravelContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbMenus.Where(m => (bool)m.IsActive).
                OrderBy(m => m.Position).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
