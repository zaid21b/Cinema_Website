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
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Event.Include(h => h.Hall).Include(m => m.Movie);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .Include(h => h.Hall)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            ViewData["HallId"] = new SelectList(_context.Hall, "HadllId", "HadllId");
            ViewData["MovieId"] = new SelectList(_context.tblMovies, "MovieId", "MovieId");
            ViewData["MovieName"] = new SelectList(_context.tblMovies, "MovieName", "MovieName");

            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,EventDateTime,HallId,MovieId,MovieName")] Event @event)
        {
           

            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details","Movies",new {id = @event.MovieId });
            }
            ViewData["HallId"] = new SelectList(_context.Hall, "HadllId", "HadllId", @event.HallId);
            ViewData["MovieId"] = new SelectList(_context.tblMovies, "MovieId", "MovieId", @event.MovieId);
            ViewData["MovieName"] = new SelectList(_context.tblMovies, "MovieName", "MovieName", @event.Movie.MovieName);
            ViewData["sendevent"] = @event;

            return View(@event);

         
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            ViewData["HallId"] = new SelectList(_context.Hall, "HadllId", "HadllId", @event.HallId);
            ViewData["MovieId"] = new SelectList(_context.tblMovies, "MovieId", "MovieId", @event.MovieId);
            ViewData["MovieName"] = new SelectList(_context.tblMovies, "MovieName", "MovieName");
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,EventDateTime,HallId,MovieId")] Event @event)
        {
            if (id != @event.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Movies", new { id = @event.MovieId });
            }
            ViewData["HallId"] = new SelectList(_context.Hall, "HadllId", "HadllId", @event.HallId);
            ViewData["MovieId"] = new SelectList(_context.tblMovies, "MovieId", "MovieId", @event.MovieId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .Include(h => h.Hall)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Movies", new { id = @event.MovieId });
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.EventId == id);
        }
    }
}
