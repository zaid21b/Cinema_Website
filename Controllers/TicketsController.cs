using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinema_Website.Data;
using Cinema_Website.Models;
using Microsoft.AspNetCore.Authorization;

namespace Cinema_Website.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            var testGPContext = _context.tblTickets.Include(t => t.Event);
            return View(await testGPContext.ToListAsync());
        }

        [Authorize(Roles = "Admin")]
        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.tblTickets
                .Include(t => t.Event)
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        [Authorize(Roles = "Admin")]
        // GET: Tickets/Create
        public IActionResult Create(int EventId,int MovieId)
        {
            ViewData["EventId"] = EventId;
            ViewData["MovieId"] = MovieId;
            
            return View();
        }
        [Authorize(Roles = "Admin")]
        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketId,TicketPrice,IsSelected,EventId,TicketType")] Ticket ticket,int nTicket,int MovieId,int ncoolplusTicket , int priceTicket)
        {
            if (ModelState.IsValid)
            {
                var i = 1;
                for (i = 1; i <= nTicket; i++)
                {
                    if (i <= ncoolplusTicket)
                    {
                        Ticket ticket1 = new Ticket();
                        ticket1.SeatNumber = i;
                        ticket1.TicketPrice = priceTicket;
                        ticket1.IsSelected = ticket.IsSelected;
                        ticket1.EventId = ticket.EventId;
                        ticket1.TicketType = Ticket.TicketTypes.coolplus;
                        ticket1.IsSold = ticket.IsSold;
                        _context.Add(ticket1);
                        await _context.SaveChangesAsync();


                    }
                    else
                    {
                        Ticket ticket1 = new Ticket();
                        ticket1.SeatNumber = i;
                        ticket1.TicketPrice = ticket.TicketPrice;
                        ticket1.IsSelected = ticket.IsSelected;
                        ticket1.EventId = ticket.EventId;
                        ticket1.TicketType = Ticket.TicketTypes.cool;
                        ticket1.IsSold = ticket.IsSold;
                        _context.Add(ticket1);
                        await _context.SaveChangesAsync();
                    }
                }


                return RedirectToAction(nameof(Details),"Movies",new {id =  MovieId});
            }
            ViewData["EventId"] = new SelectList(_context.tblEvents, "EventId", "EventId", ticket.EventId);
            return View(ticket);
        }

        [Authorize(Roles = "Admin")]
        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.tblTickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.tblEvents, "EventId", "EventId", ticket.EventId);
            return View(ticket);
        }
        [Authorize(Roles = "Admin")]
        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketId,TicketPrice,IsSelected,EventId")] Ticket ticket)
        {
            if (id != ticket.TicketId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.TicketId))
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
            ViewData["EventId"] = new SelectList(_context.tblEvents, "EventId", "EventId", ticket.EventId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.tblTickets
                .Include(t => t.Event)
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.tblTickets.FindAsync(id);
            _context.tblTickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.tblTickets.Any(e => e.TicketId == id);
        }
    }
}
