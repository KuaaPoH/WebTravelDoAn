using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebTravel.Models;

namespace WebTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ToursController : Controller
    {
        private readonly TravelContext _context;

        public ToursController(TravelContext context)
        {
            _context = context;
        }

        // GET: Admin/Tours
        public async Task<IActionResult> Index()
        {
            var travelContext = _context.TbTours.Include(t => t.CategoryTour);
            return View(await travelContext.ToListAsync());
        }

        // GET: Admin/Tours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTour = await _context.TbTours
                .Include(t => t.CategoryTour)
                .FirstOrDefaultAsync(m => m.TourId == id);
            if (tbTour == null)
            {
                return NotFound();
            }

            return View(tbTour);
        }

        // GET: Admin/Tours/Create
        public IActionResult Create()
        {
            ViewData["CategoryTourId"] = new SelectList(_context.TbTourCategories, "CategoryTourId", "Title");
            return View();
        }

        // POST: Admin/Tours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TourId,Title,Alias,CategoryTourId,Description,Detail,Image,Price,PriceSale,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsActive,Star,Location,TimeTravel")] TbTour tbTour)
        {
            if (ModelState.IsValid)
            {
                tbTour.Alias = WebTravel.Utilities.Function.TitleSlugGenerationAlias(tbTour.Title);
                _context.Add(tbTour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryTourId"] = 
                new SelectList(_context.TbTourCategories, "CategoryTourId", "CategoryTourId", tbTour.CategoryTourId);
            return View(tbTour);
        }

        // GET: Admin/Tours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTour = await _context.TbTours.FindAsync(id);
            if (tbTour == null)
            {
                return NotFound();
            }
            ViewData["CategoryTourId"] = new 
                SelectList(_context.TbTourCategories, "CategoryTourId", "Title", tbTour.CategoryTourId);
            return View(tbTour);
        }

        // POST: Admin/Tours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TourId,Title,Alias,CategoryTourId,Description,Detail,Image,Price,PriceSale,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsActive,Star,Location,TimeTravel")] TbTour tbTour)
        {
            if (id != tbTour.TourId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbTour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbTourExists(tbTour.TourId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryTourId"] = new SelectList(_context.TbTourCategories, "CategoryTourId", "CategoryTourId", tbTour.CategoryTourId);
            return View(tbTour);
        }

        // GET: Admin/Tours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTour = await _context.TbTours
                .Include(t => t.CategoryTour)
                .FirstOrDefaultAsync(m => m.TourId == id);
            if (tbTour == null)
            {
                return NotFound();
            }

            return View(tbTour);
        }

        // POST: Admin/Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbTour = await _context.TbTours.FindAsync(id);
            if (tbTour != null)
            {
                _context.TbTours.Remove(tbTour);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbTourExists(int id)
        {
            return _context.TbTours.Any(e => e.TourId == id);
        }
    }
}
