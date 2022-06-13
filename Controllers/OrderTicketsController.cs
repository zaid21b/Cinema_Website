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

namespace Cinema_Website.Controllers
{
    public class OrderTicketsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<CinemaWebsiteUser> _userManager;

        public OrderTicketsController(ApplicationDbContext context, UserManager<CinemaWebsiteUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: OrderTickets
        public async Task<IActionResult> Index()
        {
            var testGPContext = _context.tblOrderTickets.Include(o => o.Order).Include(o => o.Ticket);
            return View(await testGPContext.ToListAsync());
        }

        // GET: OrderTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderticket = await _context.tblOrderTickets
                .Include(o => o.Order)
                .Include(o => o.Ticket)
                .FirstOrDefaultAsync(m => m.OrderTicketId == id);
            if (orderticket == null)
            {
                return NotFound();
            }

            return View(orderticket);
        }

        // GET: OrderTickets/Create
        //public IActionResult Create(int OrderId,int TicketId)
        //{
        // ViewData["OrderId"] = OrderId;
        //ViewData["TicketId"] = new SelectList(_context.Ticket.Where(e => e.EventId == EventId), "TicketId", "TicketId");
        // ViewData["TicketIdd"] = TicketId;

        //  return View();
        // }

        // POST: OrderTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int TicketId, int EventId)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var OrdersCartId =  int.Parse(_context.tblOrders.Where(c => c.UserId == userId).Select(o => o.OrederId).FirstOrDefault().ToString());
                
                var orderticket = new OrderTicket();
                orderticket.TicketId = TicketId;
                orderticket.OrderId = OrdersCartId;
                _context.Add(orderticket);
                await _context.SaveChangesAsync();
                var ticket = await _context.tblTickets.FindAsync(TicketId);
                ticket.IsSelected = true;
                _context.tblTickets.Update(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), "Events", new { id = EventId});
            }
            //ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId", orderticket.OrderId);
            //ViewData["TicketId"] = new SelectList(_context.Ticket, "TicketId", "TicketId", orderticket.TicketId);
            return View(null);
        }

        // GET: OrderTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderticket = await _context.tblOrderTickets.FindAsync(id);
            if (orderticket == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.tblOrders, "OrderId", "OrderId", orderticket.OrderId);
            ViewData["TicketId"] = new SelectList(_context.tblTickets, "TicketId", "TicketId", orderticket.TicketId);
            return View(orderticket);
        }

        // POST: OrderTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderTicketId,TicketId,OrderId")] OrderTicket orderticket)
        {
            if (id != orderticket.OrderTicketId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderTicketExists(orderticket.OrderTicketId))
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
            ViewData["OrderId"] = new SelectList(_context.tblOrders, "OrderId", "OrderId", orderticket.OrderId);
            ViewData["TicketId"] = new SelectList(_context.tblTickets, "TicketId", "TicketId", orderticket.TicketId);
            return View(orderticket);
        }

        // GET: OrderTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderticket = await _context.tblOrderTickets
                .Include(o => o.Order)
                .Include(o => o.Ticket)
                .FirstOrDefaultAsync(m => m.OrderTicketId == id);
            if (orderticket == null)
            {
                return NotFound();
            }

            return View(orderticket);
        }

        // POST: OrderTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderticket = await _context.tblOrderTickets.FindAsync(id);
            _context.tblOrderTickets.Remove(orderticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderTicketExists(int id)
        {
            return _context.tblOrderTickets.Any(e => e.OrderTicketId == id);
        }
    }
}
