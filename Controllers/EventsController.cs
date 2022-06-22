using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinema_Website.Data;
using Cinema_Website.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Cinema_Website.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;



        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [Authorize(Roles = "Admin")]
        // GET: Events
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.tblEvents.Include(h => h.Hall).Include(m => m.Movie);
            return View(await applicationDbContext.ToListAsync());
        }


        [Authorize(Roles = "Customer,Admin")]
        // GET: Events/Details/5
        public async Task<IActionResult> Details(double TotalPrice,int NumOfSelectedTickets, int? id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["OrderId"] = int.Parse(_context.tblOrders.Where(c => c.UserId == userId).Select(o => o.OrederId).FirstOrDefault().ToString());
            
            if (id == null)
            {
                return NotFound();
            }

            
            var @event = await _context.tblEvents
            .Include(h => h.Hall)
            .Include(m => m.Movie)
            .Include(e => e.Tickets)
            .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

           

            return View(@event);
        }


        [Authorize(Roles = "Admin")]
        // GET: Events/Create
        public IActionResult Create()
        {
            ViewData["HallId"] = new SelectList(_context.tblHalls, "HadllId", "HallNumber");
            ViewData["MovieId"] = new SelectList(_context.tblMovies, "MovieId", "MovieName");



            return View();
        }


        [Authorize(Roles = "Admin")]
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
                return RedirectToAction(nameof(Create), "Tickets", new { EventId = @event.EventId, MovieId = @event.MovieId });
            }
            ViewData["HallId"] = new SelectList(_context.tblHalls, "HadllId", "HadllId", @event.HallId);
            ViewData["MovieId"] = new SelectList(_context.tblMovies, "MovieId", "MovieId", @event.MovieId);
            ViewData["MovieName"] = new SelectList(_context.tblMovies, "MovieName", "MovieName", @event.Movie.MovieName);

            return View(@event);
        }


        [Authorize(Roles = "Admin")]
        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            var @event = await _context.tblEvents.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            ViewData["HallId"] = new SelectList(_context.tblHalls, "HadllId", "HallNumber", @event.HallId);
            ViewData["MovieId"] = new SelectList(_context.tblMovies, "MovieId", "MovieName", @event.MovieId);
            return View(@event);
        }


        [Authorize(Roles = "Admin")]
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
                return RedirectToAction(nameof(Details), "Movies", new { id = @event.MovieId });
            }
            ViewData["HallId"] = new SelectList(_context.tblHalls, "HadllId", "HadllId", @event.HallId);
            ViewData["MovieId"] = new SelectList(_context.tblMovies, "MovieId", "MovieId", @event.MovieId);
            return View(@event);
        }


        [Authorize(Roles = "Admin")]
        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            var @event = await _context.tblEvents
            .Include(h => h.Hall)
            .Include(m => m.Movie)
            .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }



            return View(@event);
        }


        [Authorize(Roles = "Admin")]
        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.tblEvents.FindAsync(id);
            _context.tblEvents.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), "Movies", new { id = @event.MovieId });
        }



        private bool EventExists(int id)
        {
            return _context.tblEvents.Any(e => e.EventId == id);
        }
    }
}