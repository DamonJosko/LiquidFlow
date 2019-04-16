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
    public class CountyStateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountyStateController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CountyState
        public async Task<IActionResult> Index()
        {
            return View(await _context.CountyStates.ToListAsync());
        }

        // GET: CountyState/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countyState = await _context.CountyStates
                .FirstOrDefaultAsync(m => m.CountyStateID == id);
            if (countyState == null)
            {
                return NotFound();
            }

            return View(countyState);
        }

        // GET: CountyState/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CountyState/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountyStateID,CountyName")] CountyState countyState)
        {
            if (ModelState.IsValid)
            {
                _context.Add(countyState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(countyState);
        }

        // GET: CountyState/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countyState = await _context.CountyStates.FindAsync(id);
            if (countyState == null)
            {
                return NotFound();
            }
            return View(countyState);
        }

        // POST: CountyState/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CountyStateID,CountyName")] CountyState countyState)
        {
            if (id != countyState.CountyStateID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(countyState);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountyStateExists(countyState.CountyStateID))
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
            return View(countyState);
        }

        // GET: CountyState/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countyState = await _context.CountyStates
                .FirstOrDefaultAsync(m => m.CountyStateID == id);
            if (countyState == null)
            {
                return NotFound();
            }

            return View(countyState);
        }

        // POST: CountyState/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var countyState = await _context.CountyStates.FindAsync(id);
            _context.CountyStates.Remove(countyState);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountyStateExists(int id)
        {
            return _context.CountyStates.Any(e => e.CountyStateID == id);
        }
    }
}
