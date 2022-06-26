using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinema_Website.Data;
using Cinema_Website.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Cinema_Website.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MoviesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.tblMovies.ToListAsync());
        }

        

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.tblMovies
                .Include(m => m.Events).ThenInclude(e => e.Hall)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
        [Authorize(Roles = "Admin")]
        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,MovieName,MovieDescription,MovieImage,MovieTrailer,Generes,RunTime,MMPARating,ReleaseDate,SH")] Movie movie, IFormFile MovieImage)
        {
            if (MovieImage != null)
            {
                string guid = Guid.NewGuid().ToString();
                var FullFileName = $"{_webHostEnvironment.WebRootPath}\\images\\{guid}_{Path.GetFileName(MovieImage.FileName)}";
                //This code is used to copy image to WWRoot
                using (var myStream = new FileStream(FullFileName, FileMode.Create))
                {
                    MovieImage.CopyTo(myStream);
                }
                movie.MovieImage = $"/images/{ guid}_{ Path.GetFileName(MovieImage.FileName)}";
            }

            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }
        [Authorize(Roles = "Admin")]
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
            return View(movie);
        }
        [Authorize(Roles = "Admin")]
        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,MovieName,MovieDescription,MovieImage,MovieTrailer,Generes,RunTime,MMPARating,ReleaseDate,SH")] Movie movie)
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
                return RedirectToAction(nameof(Details), new { id = movie.MovieId });
            }
            return View(movie);
        }
        [Authorize(Roles = "Admin")]
        //GET
        public async Task<IActionResult> EditMovieImage(int? id)
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
            return View(movie);
        }
        [Authorize(Roles = "Admin")]
        //POST
        [HttpPost]
        public async Task<IActionResult> EditMovieImage(int id, [Bind("MovieId,MovieName,MovieDescription,MovieImage,MovieTrailer,Generes,RunTime,MMPARating,ReleaseDate,SH")] Movie movie, IFormFile MovieImage)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (MovieImage != null)
            {
                string guid = Guid.NewGuid().ToString();
                var FullFileName = $"{_webHostEnvironment.WebRootPath}\\images\\{guid}_{Path.GetFileName(MovieImage.FileName)}";
                //This code is used to copy image to WWRoot
                using (var myStream = new FileStream(FullFileName, FileMode.Create))
                {
                    MovieImage.CopyTo(myStream);
                }
                movie.MovieImage = $"/images/{ guid}_{ Path.GetFileName(MovieImage.FileName)}";
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
                return RedirectToAction(nameof(Edit), new { id = movie.MovieId });
            }
            return View(movie);

        }
        [Authorize(Roles = "Admin")]
        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.tblMovies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
        [Authorize(Roles = "Admin")]
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
