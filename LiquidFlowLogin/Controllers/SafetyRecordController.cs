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
    public class SafetyRecordController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SafetyRecordController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SafetyRecord
        public async Task<IActionResult> Index()
        {
            return View(await _context.SafetyRecords.ToListAsync());
        }

        // GET: SafetyRecord/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var safetyRecord = await _context.SafetyRecords
                .FirstOrDefaultAsync(m => m.SafetyRecordID == id);
            if (safetyRecord == null)
            {
                return NotFound();
            }

            return View(safetyRecord);
        }

        // GET: SafetyRecord/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SafetyRecord/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SafetyRecordID,SafetyRecordDetail")] SafetyRecord safetyRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(safetyRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(safetyRecord);
        }

        // GET: SafetyRecord/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var safetyRecord = await _context.SafetyRecords.FindAsync(id);
            if (safetyRecord == null)
            {
                return NotFound();
            }
            return View(safetyRecord);
        }

        // POST: SafetyRecord/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SafetyRecordID,SafetyRecordDetail")] SafetyRecord safetyRecord)
        {
            if (id != safetyRecord.SafetyRecordID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(safetyRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SafetyRecordExists(safetyRecord.SafetyRecordID))
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
            return View(safetyRecord);
        }

        // GET: SafetyRecord/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var safetyRecord = await _context.SafetyRecords
                .FirstOrDefaultAsync(m => m.SafetyRecordID == id);
            if (safetyRecord == null)
            {
                return NotFound();
            }

            return View(safetyRecord);
        }

        // POST: SafetyRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var safetyRecord = await _context.SafetyRecords.FindAsync(id);
            _context.SafetyRecords.Remove(safetyRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SafetyRecordExists(int id)
        {
            return _context.SafetyRecords.Any(e => e.SafetyRecordID == id);
        }
    }
}
