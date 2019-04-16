using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiquidFlowLogin.Data;
using LiquidFlowLogin.Models;
using Microsoft.AspNetCore.Authorization;

namespace LiquidFlowLogin.Controllers
{
    [Authorize]
    public class OrderRocketPropellantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderRocketPropellantController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrderRocketPropellant
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrderRocketPropellants.Include(o => o.Order).Include(o => o.RocketPropellant);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrderRocketPropellant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderRocketPropellant = await _context.OrderRocketPropellants
                .Include(o => o.Order)
                .Include(o => o.RocketPropellant)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (orderRocketPropellant == null)
            {
                return NotFound();
            }

            return View(orderRocketPropellant);
        }

        // GET: OrderRocketPropellant/Create
        public IActionResult Create()
        {
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "OrderID");
            ViewData["RocketPropellantID"] = new SelectList(_context.RocketPropellants, "RocketPropellantID", "RocketPropellantID");
            return View();
        }

        // POST: OrderRocketPropellant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,RocketPropellantID,OrderRocketPropellantAmount,OrderRocketPropellantCost")] OrderRocketPropellant orderRocketPropellant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderRocketPropellant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "OrderID", orderRocketPropellant.OrderID);
            ViewData["RocketPropellantID"] = new SelectList(_context.RocketPropellants, "RocketPropellantID", "RocketPropellantID", orderRocketPropellant.RocketPropellantID);
            return View(orderRocketPropellant);
        }

        // GET: OrderRocketPropellant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderRocketPropellant = await _context.OrderRocketPropellants.FindAsync(id);
            if (orderRocketPropellant == null)
            {
                return NotFound();
            }
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "OrderID", orderRocketPropellant.OrderID);
            ViewData["RocketPropellantID"] = new SelectList(_context.RocketPropellants, "RocketPropellantID", "RocketPropellantID", orderRocketPropellant.RocketPropellantID);
            return View(orderRocketPropellant);
        }

        // POST: OrderRocketPropellant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,RocketPropellantID,OrderRocketPropellantAmount,OrderRocketPropellantCost")] OrderRocketPropellant orderRocketPropellant)
        {
            if (id != orderRocketPropellant.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderRocketPropellant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderRocketPropellantExists(orderRocketPropellant.OrderID))
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
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "OrderID", orderRocketPropellant.OrderID);
            ViewData["RocketPropellantID"] = new SelectList(_context.RocketPropellants, "RocketPropellantID", "RocketPropellantID", orderRocketPropellant.RocketPropellantID);
            return View(orderRocketPropellant);
        }

        // GET: OrderRocketPropellant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderRocketPropellant = await _context.OrderRocketPropellants
                .Include(o => o.Order)
                .Include(o => o.RocketPropellant)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (orderRocketPropellant == null)
            {
                return NotFound();
            }

            return View(orderRocketPropellant);
        }

        // POST: OrderRocketPropellant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderRocketPropellant = await _context.OrderRocketPropellants.FindAsync(id);
            _context.OrderRocketPropellants.Remove(orderRocketPropellant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderRocketPropellantExists(int id)
        {
            return _context.OrderRocketPropellants.Any(e => e.OrderID == id);
        }
    }
}
