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
    public class RocketController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RocketController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rocket
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rockets.Include(r => r.Company).Include(r => r.RocketName).Include(r => r.RocketPropellant);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rocket/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rocket = await _context.Rockets
                .Include(r => r.Company)
                .Include(r => r.RocketName)
                .Include(r => r.RocketPropellant)
                .FirstOrDefaultAsync(m => m.RocketID == id);
            if (rocket == null)
            {
                return NotFound();
            }

            return View(rocket);
        }

        // GET: Rocket/Create
        public IActionResult Create()
        {
            ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyID");
            ViewData["RocketNameID"] = new SelectList(_context.RocketNames, "RocketNameID", "RocketNameID");
            ViewData["RocketPropellantID"] = new SelectList(_context.RocketPropellants, "RocketPropellantID", "RocketPropellantID");
            return View();
        }

        // POST: Rocket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RocketID,RocketNameID,RocketModel,CompanyID,RocketPropellantID,PropellantMaxCapacity,PropellantCurrentCapacity")] Rocket rocket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rocket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyID", rocket.CompanyID);
            ViewData["RocketNameID"] = new SelectList(_context.RocketNames, "RocketNameID", "RocketNameID", rocket.RocketNameID);
            ViewData["RocketPropellantID"] = new SelectList(_context.RocketPropellants, "RocketPropellantID", "RocketPropellantID", rocket.RocketPropellantID);
            return View(rocket);
        }

        // GET: Rocket/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rocket = await _context.Rockets.FindAsync(id);
            if (rocket == null)
            {
                return NotFound();
            }
            ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyID", rocket.CompanyID);
            ViewData["RocketNameID"] = new SelectList(_context.RocketNames, "RocketNameID", "RocketNameID", rocket.RocketNameID);
            ViewData["RocketPropellantID"] = new SelectList(_context.RocketPropellants, "RocketPropellantID", "RocketPropellantID", rocket.RocketPropellantID);
            return View(rocket);
        }

        // POST: Rocket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RocketID,RocketNameID,RocketModel,CompanyID,RocketPropellantID,PropellantMaxCapacity,PropellantCurrentCapacity")] Rocket rocket)
        {
            if (id != rocket.RocketID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rocket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RocketExists(rocket.RocketID))
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
            ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyID", rocket.CompanyID);
            ViewData["RocketNameID"] = new SelectList(_context.RocketNames, "RocketNameID", "RocketNameID", rocket.RocketNameID);
            ViewData["RocketPropellantID"] = new SelectList(_context.RocketPropellants, "RocketPropellantID", "RocketPropellantID", rocket.RocketPropellantID);
            return View(rocket);
        }

        // GET: Rocket/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rocket = await _context.Rockets
                .Include(r => r.Company)
                .Include(r => r.RocketName)
                .Include(r => r.RocketPropellant)
                .FirstOrDefaultAsync(m => m.RocketID == id);
            if (rocket == null)
            {
                return NotFound();
            }

            return View(rocket);
        }

        // POST: Rocket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rocket = await _context.Rockets.FindAsync(id);
            _context.Rockets.Remove(rocket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RocketExists(int id)
        {
            return _context.Rockets.Any(e => e.RocketID == id);
        }
    }
}
