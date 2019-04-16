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
    public class RocketFuelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RocketFuelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RocketFuel
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RocketFuels.Include(r => r.FuelType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RocketFuel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rocketFuel = await _context.RocketFuels
                .Include(r => r.FuelType)
                .FirstOrDefaultAsync(m => m.RocketFuelID == id);
            if (rocketFuel == null)
            {
                return NotFound();
            }

            return View(rocketFuel);
        }

        // GET: RocketFuel/Create
        public IActionResult Create()
        {
            ViewData["FuelTypeID"] = new SelectList(_context.FuelTypes, "FuelTypeID", "FuelTypeID");
            return View();
        }

        // POST: RocketFuel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RocketFuelID,FuelName,FuelTypeID,FuelAmount,FuelPrice,BuyCost")] RocketFuel rocketFuel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rocketFuel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuelTypeID"] = new SelectList(_context.FuelTypes, "FuelTypeID", "FuelTypeID", rocketFuel.FuelTypeID);
            return View(rocketFuel);
        }

        // GET: RocketFuel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rocketFuel = await _context.RocketFuels.FindAsync(id);
            if (rocketFuel == null)
            {
                return NotFound();
            }
            ViewData["FuelTypeID"] = new SelectList(_context.FuelTypes, "FuelTypeID", "FuelTypeID", rocketFuel.FuelTypeID);
            return View(rocketFuel);
        }

        // POST: RocketFuel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RocketFuelID,FuelName,FuelTypeID,FuelAmount,FuelPrice,BuyCost")] RocketFuel rocketFuel)
        {
            if (id != rocketFuel.RocketFuelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rocketFuel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RocketFuelExists(rocketFuel.RocketFuelID))
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
            ViewData["FuelTypeID"] = new SelectList(_context.FuelTypes, "FuelTypeID", "FuelTypeID", rocketFuel.FuelTypeID);
            return View(rocketFuel);
        }

        // GET: RocketFuel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rocketFuel = await _context.RocketFuels
                .Include(r => r.FuelType)
                .FirstOrDefaultAsync(m => m.RocketFuelID == id);
            if (rocketFuel == null)
            {
                return NotFound();
            }

            return View(rocketFuel);
        }

        // POST: RocketFuel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rocketFuel = await _context.RocketFuels.FindAsync(id);
            _context.RocketFuels.Remove(rocketFuel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RocketFuelExists(int id)
        {
            return _context.RocketFuels.Any(e => e.RocketFuelID == id);
        }
    }
}
