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
    public class RocketOxidizerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RocketOxidizerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RocketOxidizer
        public async Task<IActionResult> Index()
        {
            return View(await _context.RocketOxidizers.ToListAsync());
        }

        // GET: RocketOxidizer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rocketOxidizer = await _context.RocketOxidizers
                .FirstOrDefaultAsync(m => m.RocketOxidizerID == id);
            if (rocketOxidizer == null)
            {
                return NotFound();
            }

            return View(rocketOxidizer);
        }

        // GET: RocketOxidizer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RocketOxidizer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RocketOxidizerID,OxidizerName,OxidizerAmount,OxidizerPrice,BuyCost")] RocketOxidizer rocketOxidizer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rocketOxidizer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rocketOxidizer);
        }

        // GET: RocketOxidizer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rocketOxidizer = await _context.RocketOxidizers.FindAsync(id);
            if (rocketOxidizer == null)
            {
                return NotFound();
            }
            return View(rocketOxidizer);
        }

        // POST: RocketOxidizer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RocketOxidizerID,OxidizerName,OxidizerAmount,OxidizerPrice,BuyCost")] RocketOxidizer rocketOxidizer)
        {
            if (id != rocketOxidizer.RocketOxidizerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rocketOxidizer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RocketOxidizerExists(rocketOxidizer.RocketOxidizerID))
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
            return View(rocketOxidizer);
        }

        // GET: RocketOxidizer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rocketOxidizer = await _context.RocketOxidizers
                .FirstOrDefaultAsync(m => m.RocketOxidizerID == id);
            if (rocketOxidizer == null)
            {
                return NotFound();
            }

            return View(rocketOxidizer);
        }

        // POST: RocketOxidizer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rocketOxidizer = await _context.RocketOxidizers.FindAsync(id);
            _context.RocketOxidizers.Remove(rocketOxidizer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RocketOxidizerExists(int id)
        {
            return _context.RocketOxidizers.Any(e => e.RocketOxidizerID == id);
        }
    }
}
