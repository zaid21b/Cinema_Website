using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaWebsite2.Data;
using Cinema_Website.Models;

namespace CinemaWebsite2.Controllers
{
    public class AddingCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddingCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AddingCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.tblAddingCategories.ToListAsync());
        }

        // GET: AddingCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addingCategory = await _context.tblAddingCategories
                .FirstOrDefaultAsync(m => m.AddingCategoryId == id);
            if (addingCategory == null)
            {
                return NotFound();
            }

            return View(addingCategory);
        }

        // GET: AddingCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddingCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AddingCategoryId,MovieId,CategoryId")] AddingCategory addingCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addingCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addingCategory);
        }

        // GET: AddingCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addingCategory = await _context.tblAddingCategories.FindAsync(id);
            if (addingCategory == null)
            {
                return NotFound();
            }
            return View(addingCategory);
        }

        // POST: AddingCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddingCategoryId,MovieId,CategoryId")] AddingCategory addingCategory)
        {
            if (id != addingCategory.AddingCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addingCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddingCategoryExists(addingCategory.AddingCategoryId))
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
            return View(addingCategory);
        }

        // GET: AddingCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addingCategory = await _context.tblAddingCategories
                .FirstOrDefaultAsync(m => m.AddingCategoryId == id);
            if (addingCategory == null)
            {
                return NotFound();
            }

            return View(addingCategory);
        }

        // POST: AddingCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addingCategory = await _context.tblAddingCategories.FindAsync(id);
            _context.tblAddingCategories.Remove(addingCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddingCategoryExists(int id)
        {
            return _context.tblAddingCategories.Any(e => e.AddingCategoryId == id);
        }
    }
}
