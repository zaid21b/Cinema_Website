using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaWebsite2.Data;
using Cinema_Website.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace CinemaWebsite2.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.tblMovies.Include(m => m.Admin);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.tblMovies
                .Include(m => m.Admin)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewData["AdminId"] = new SelectList(items: _context.Set<Admin>(),
                                                 dataValueField: "AdminId",
                                                 dataTextField: "FirstName");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,MovieName,MovieDescription,MovieImage,MovieTrailer,AdminId")] Movie movie, IFormFile MovieImage, IFormFile MovieTrailer)
        {
            if (MovieImage != null)
            {
                //This code is used to copy image to DataBase
                using (var myStream = new MemoryStream())
                {
                    await MovieImage.CopyToAsync(myStream);
                    movie.MovieImage = myStream.ToArray();
                }
            }
            if (MovieTrailer != null)
            {
                //This code is used to copy image to DataBase
                using (var myStream = new MemoryStream())
                {
                    await MovieTrailer.CopyToAsync(myStream);
                    movie.MovieTrailer = myStream.ToArray();
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminId"] = new SelectList(_context.Set<Admin>(), "AdminId", "Email", movie.AdminId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.tblMovies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["AdminId"] = new SelectList(_context.Set<Admin>(), "AdminId", "Email", selectedValue: movie.AdminId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,MovieName,MovieDescription,MovieImage,MovieTrailer,AdminId")] Movie movie)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId))
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
            ViewData["AdminId"] = new SelectList(_context.Set<Admin>(), "AdminId", "Email", movie.AdminId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.tblMovies
                .Include(m => m.Admin)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.tblMovies.FindAsync(id);
            _context.tblMovies.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.tblMovies.Any(e => e.MovieId == id);
        }
    }
}
