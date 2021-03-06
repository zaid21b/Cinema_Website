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
using System.Security.Claims;

namespace Cinema_Website.Controllers
{
    public class OrdersCartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersCartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        // GET: Orders
        // GET: Orders
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.tblOrders.ToListAsync());
        }

        public IActionResult PassData()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var OrdersCartId = int.Parse(_context.tblOrders.Where(c => c.UserId == userId).Select(o => o.OrederId).FirstOrDefault().ToString());
            return RedirectToAction("Details",new {id = OrdersCartId });
        }
        public IActionResult PassData2()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var OrdersCartId = int.Parse(_context.tblOrders.Where(c => c.UserId == userId).Select(o => o.OrederId).FirstOrDefault().ToString());
            return RedirectToAction("MyTicket", new { id = OrdersCartId });
        }
        public async Task<IActionResult> MyTicket(int? id)
        {
            var cart = await _context.tblOrders
                .Include(ot => ot.OrderTickets)
                .ThenInclude(t => t.Ticket)
                .ThenInclude(e => e.Event)
                .ThenInclude(m => m.Movie)
                .Include(ot => ot.OrderTickets)
                .ThenInclude(t => t.Ticket)
                .ThenInclude(e => e.Event)
                .ThenInclude(h => h.Hall)
                .FirstOrDefaultAsync(oi => oi.OrederId == id);

            return View("MyTicket",cart);


        }



        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.tblOrders
                .Include(ot => ot.OrderTickets)
                .ThenInclude(t => t.Ticket)
                .ThenInclude(e => e.Event)
                .ThenInclude(m => m.Movie)
                .Include(ot => ot.OrderTickets)
                .ThenInclude(t => t.Ticket)
                .ThenInclude(e => e.Event)
                .ThenInclude(h => h.Hall)
                .FirstOrDefaultAsync(m => m.OrederId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        //public IActionResult Create()
        //{
        //  return View();
        //}

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int EventId, int TicketId)
        {
            if (ModelState.IsValid)
            {
                var order = new OrdersCart();
                //order.UserId = "1";
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create), "OrderTickets", new { OrderId = order.OrederId, TicketId = TicketId, EventId = EventId });
            }
            return View(null);
        }

        [Authorize(Roles = "Admin")]
        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.tblOrders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [Authorize(Roles = "Admin")]
        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId")] OrdersCart order)
        {
            if (id != order.OrederId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrederId))
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
            return View(order);
        }

        
        public async Task<IActionResult> SetIsSold(int id)
        {
            var cart = await _context.tblOrders.Include(c => c.OrderTickets)
            .ThenInclude(t => t.Ticket)
            .FirstOrDefaultAsync(o => o.OrederId == id);
            var tickets = cart.OrderTickets; 
            foreach (var item in tickets)
            {
                item.Ticket.IsSold = true;
            }
            await _context.SaveChangesAsync();
            return ((IActionResult)cart);
        }
        public async Task<IActionResult> Checkout(int id)
        {
            var cart = await _context.tblOrders.Include(o => o.OrderTickets)
                .ThenInclude(t => t.Ticket)
                .ThenInclude(e => e.Event)
                .ThenInclude(m => m.Movie)
                .Include(o => o.OrderTickets)
                .ThenInclude(t => t.Ticket)
                .ThenInclude(e => e.Event)
                .ThenInclude(h => h.Hall)
                .FirstOrDefaultAsync(c => c.OrederId == id);
            
            return View("Checkout",cart);

        }


        [Authorize(Roles = "Admin")]
        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.tblOrders
                .FirstOrDefaultAsync(m => m.OrederId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [Authorize(Roles = "Admin")]
        // POST: Orders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.tblOrders.FindAsync(id);
            _context.tblOrders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Events");
        }

        private bool OrderExists(int id)
        {
            return _context.tblOrders.Any(e => e.OrederId == id);
        }
    }
}
