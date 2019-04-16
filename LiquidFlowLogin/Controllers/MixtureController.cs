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
    public class MixtureController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MixtureController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mixture
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mixtures.ToListAsync());
        }

        // GET: Mixture/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mixture = await _context.Mixtures
                .FirstOrDefaultAsync(m => m.MixtureID == id);
            if (mixture == null)
            {
                return NotFound();
            }

            return View(mixture);
        }

        // GET: Mixture/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mixture/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MixtureID,MixtureRatio")] Mixture mixture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mixture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mixture);
        }

        // GET: Mixture/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mixture = await _context.Mixtures.FindAsync(id);
            if (mixture == null)
            {
                return NotFound();
            }
            return View(mixture);
        }

        // POST: Mixture/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MixtureID,MixtureRatio")] Mixture mixture)
        {
            if (id != mixture.MixtureID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mixture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MixtureExists(mixture.MixtureID))
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
            return View(mixture);
        }

        // GET: Mixture/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mixture = await _context.Mixtures
                .FirstOrDefaultAsync(m => m.MixtureID == id);
            if (mixture == null)
            {
                return NotFound();
            }

            return View(mixture);
        }

        // POST: Mixture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mixture = await _context.Mixtures.FindAsync(id);
            _context.Mixtures.Remove(mixture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MixtureExists(int id)
        {
            return _context.Mixtures.Any(e => e.MixtureID == id);
        }
    }
}
