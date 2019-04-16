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
    public class FuelTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FuelTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FuelType
        public async Task<IActionResult> Index()
        {
            return View(await _context.FuelTypes.ToListAsync());
        }

        // GET: FuelType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelType = await _context.FuelTypes
                .FirstOrDefaultAsync(m => m.FuelTypeID == id);
            if (fuelType == null)
            {
                return NotFound();
            }

            return View(fuelType);
        }

        // GET: FuelType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FuelType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuelTypeID,FuelTypeName")] FuelType fuelType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fuelType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fuelType);
        }

        // GET: FuelType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelType = await _context.FuelTypes.FindAsync(id);
            if (fuelType == null)
            {
                return NotFound();
            }
            return View(fuelType);
        }

        // POST: FuelType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuelTypeID,FuelTypeName")] FuelType fuelType)
        {
            if (id != fuelType.FuelTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fuelType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuelTypeExists(fuelType.FuelTypeID))
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
            return View(fuelType);
        }

        // GET: FuelType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelType = await _context.FuelTypes
                .FirstOrDefaultAsync(m => m.FuelTypeID == id);
            if (fuelType == null)
            {
                return NotFound();
            }

            return View(fuelType);
        }

        // POST: FuelType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fuelType = await _context.FuelTypes.FindAsync(id);
            _context.FuelTypes.Remove(fuelType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuelTypeExists(int id)
        {
            return _context.FuelTypes.Any(e => e.FuelTypeID == id);
        }
    }
}
