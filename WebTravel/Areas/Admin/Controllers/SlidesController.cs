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
    public class SlidesController : Controller
    {
        private readonly TravelContext _context;

        public SlidesController(TravelContext context)
        {
            _context = context;
        }

        // GET: Admin/Slides
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbSlides.ToListAsync());
        }

        // GET: Admin/Slides/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSlide = await _context.TbSlides
                .FirstOrDefaultAsync(m => m.SlideId == id);
            if (tbSlide == null)
            {
                return NotFound();
            }

            return View(tbSlide);
        }

        // GET: Admin/Slides/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Slides/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SlideId,Title,Alias,Image,IsActive")] TbSlide tbSlide)
        {
            if (ModelState.IsValid)
            {
                tbSlide.Alias = WebTravel.Utilities.Function.TitleSlugGenerationAlias(tbSlide.Title);
                _context.Add(tbSlide);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbSlide);
        }

        // GET: Admin/Slides/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSlide = await _context.TbSlides.FindAsync(id);
            if (tbSlide == null)
            {
                return NotFound();
            }
            return View(tbSlide);
        }

        // POST: Admin/Slides/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SlideId,Title,Alias,Image,IsActive")] TbSlide tbSlide)
        {
            if (id != tbSlide.SlideId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbSlide);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbSlideExists(tbSlide.SlideId))
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
            return View(tbSlide);
        }

        // GET: Admin/Slides/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSlide = await _context.TbSlides
                .FirstOrDefaultAsync(m => m.SlideId == id);
            if (tbSlide == null)
            {
                return NotFound();
            }

            return View(tbSlide);
        }

        // POST: Admin/Slides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbSlide = await _context.TbSlides.FindAsync(id);
            if (tbSlide != null)
            {
                _context.TbSlides.Remove(tbSlide);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbSlideExists(int id)
        {
            return _context.TbSlides.Any(e => e.SlideId == id);
        }
    }
}
