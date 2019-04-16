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
    public class RocketPropellantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RocketPropellantController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RocketPropellant
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RocketPropellants.Include(r => r.Mixture).Include(r => r.RocketFuel).Include(r => r.RocketOxidizer).Include(r => r.SafetyRecord).Include(r => r.SupplierName);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RocketPropellant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rocketPropellant = await _context.RocketPropellants
                .Include(r => r.Mixture)
                .Include(r => r.RocketFuel)
                .Include(r => r.RocketOxidizer)
                .Include(r => r.SafetyRecord)
                .Include(r => r.SupplierName)
                .FirstOrDefaultAsync(m => m.RocketPropellantID == id);
            if (rocketPropellant == null)
            {
                return NotFound();
            }

            return View(rocketPropellant);
        }

        // GET: RocketPropellant/Create
        public IActionResult Create()
        {
            ViewData["MixtureID"] = new SelectList(_context.Mixtures, "MixtureID", "MixtureID");
            ViewData["RocketFuelID"] = new SelectList(_context.RocketFuels, "RocketFuelID", "RocketFuelID");
            ViewData["RocketOxidizerID"] = new SelectList(_context.RocketOxidizers, "RocketOxidizerID", "RocketOxidizerID");
            ViewData["SafetyRecordID"] = new SelectList(_context.SafetyRecords, "SafetyRecordID", "SafetyRecordID");
            ViewData["SupplierNameID"] = new SelectList(_context.SupplierNames, "SupplierNameID", "SupplierNameID");
            return View();
        }

        // POST: RocketPropellant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RocketPropellantID,RocketFuelID,RocketOxidizerID,MixtureID,SupplierNameID,SafetyRecordID")] RocketPropellant rocketPropellant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rocketPropellant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MixtureID"] = new SelectList(_context.Mixtures, "MixtureID", "MixtureID", rocketPropellant.MixtureID);
            ViewData["RocketFuelID"] = new SelectList(_context.RocketFuels, "RocketFuelID", "RocketFuelID", rocketPropellant.RocketFuelID);
            ViewData["RocketOxidizerID"] = new SelectList(_context.RocketOxidizers, "RocketOxidizerID", "RocketOxidizerID", rocketPropellant.RocketOxidizerID);
            ViewData["SafetyRecordID"] = new SelectList(_context.SafetyRecords, "SafetyRecordID", "SafetyRecordID", rocketPropellant.SafetyRecordID);
            ViewData["SupplierNameID"] = new SelectList(_context.SupplierNames, "SupplierNameID", "SupplierNameID", rocketPropellant.SupplierNameID);
            return View(rocketPropellant);
        }

        // GET: RocketPropellant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rocketPropellant = await _context.RocketPropellants.FindAsync(id);
            if (rocketPropellant == null)
            {
                return NotFound();
            }
            ViewData["MixtureID"] = new SelectList(_context.Mixtures, "MixtureID", "MixtureID", rocketPropellant.MixtureID);
            ViewData["RocketFuelID"] = new SelectList(_context.RocketFuels, "RocketFuelID", "RocketFuelID", rocketPropellant.RocketFuelID);
            ViewData["RocketOxidizerID"] = new SelectList(_context.RocketOxidizers, "RocketOxidizerID", "RocketOxidizerID", rocketPropellant.RocketOxidizerID);
            ViewData["SafetyRecordID"] = new SelectList(_context.SafetyRecords, "SafetyRecordID", "SafetyRecordID", rocketPropellant.SafetyRecordID);
            ViewData["SupplierNameID"] = new SelectList(_context.SupplierNames, "SupplierNameID", "SupplierNameID", rocketPropellant.SupplierNameID);
            return View(rocketPropellant);
        }

        // POST: RocketPropellant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RocketPropellantID,RocketFuelID,RocketOxidizerID,MixtureID,SupplierNameID,SafetyRecordID")] RocketPropellant rocketPropellant)
        {
            if (id != rocketPropellant.RocketPropellantID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rocketPropellant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RocketPropellantExists(rocketPropellant.RocketPropellantID))
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
            ViewData["MixtureID"] = new SelectList(_context.Mixtures, "MixtureID", "MixtureID", rocketPropellant.MixtureID);
            ViewData["RocketFuelID"] = new SelectList(_context.RocketFuels, "RocketFuelID", "RocketFuelID", rocketPropellant.RocketFuelID);
            ViewData["RocketOxidizerID"] = new SelectList(_context.RocketOxidizers, "RocketOxidizerID", "RocketOxidizerID", rocketPropellant.RocketOxidizerID);
            ViewData["SafetyRecordID"] = new SelectList(_context.SafetyRecords, "SafetyRecordID", "SafetyRecordID", rocketPropellant.SafetyRecordID);
            ViewData["SupplierNameID"] = new SelectList(_context.SupplierNames, "SupplierNameID", "SupplierNameID", rocketPropellant.SupplierNameID);
            return View(rocketPropellant);
        }

        // GET: RocketPropellant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rocketPropellant = await _context.RocketPropellants
                .Include(r => r.Mixture)
                .Include(r => r.RocketFuel)
                .Include(r => r.RocketOxidizer)
                .Include(r => r.SafetyRecord)
                .Include(r => r.SupplierName)
                .FirstOrDefaultAsync(m => m.RocketPropellantID == id);
            if (rocketPropellant == null)
            {
                return NotFound();
            }

            return View(rocketPropellant);
        }

        // POST: RocketPropellant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rocketPropellant = await _context.RocketPropellants.FindAsync(id);
            _context.RocketPropellants.Remove(rocketPropellant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RocketPropellantExists(int id)
        {
            return _context.RocketPropellants.Any(e => e.RocketPropellantID == id);
        }
    }
}
