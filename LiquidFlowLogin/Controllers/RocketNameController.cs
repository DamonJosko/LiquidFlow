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
    public class RocketNameController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RocketNameController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RocketName
        public async Task<IActionResult> Index()
        {
            return View(await _context.RocketNames.ToListAsync());
        }

        // GET: RocketName/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rocketName = await _context.RocketNames
                .FirstOrDefaultAsync(m => m.RocketNameID == id);
            if (rocketName == null)
            {
                return NotFound();
            }

            return View(rocketName);
        }

        // GET: RocketName/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RocketName/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RocketNameID,RName")] RocketName rocketName)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rocketName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rocketName);
        }

        // GET: RocketName/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rocketName = await _context.RocketNames.FindAsync(id);
            if (rocketName == null)
            {
                return NotFound();
            }
            return View(rocketName);
        }

        // POST: RocketName/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RocketNameID,RName")] RocketName rocketName)
        {
            if (id != rocketName.RocketNameID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rocketName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RocketNameExists(rocketName.RocketNameID))
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
            return View(rocketName);
        }

        // GET: RocketName/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rocketName = await _context.RocketNames
                .FirstOrDefaultAsync(m => m.RocketNameID == id);
            if (rocketName == null)
            {
                return NotFound();
            }

            return View(rocketName);
        }

        // POST: RocketName/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rocketName = await _context.RocketNames.FindAsync(id);
            _context.RocketNames.Remove(rocketName);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RocketNameExists(int id)
        {
            return _context.RocketNames.Any(e => e.RocketNameID == id);
        }
    }
}
