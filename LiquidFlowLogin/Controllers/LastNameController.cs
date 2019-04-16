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
    public class LastNameController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LastNameController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LastName
        public async Task<IActionResult> Index()
        {
            return View(await _context.LastNames.ToListAsync());
        }

        // GET: LastName/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lastName = await _context.LastNames
                .FirstOrDefaultAsync(m => m.LastNameID == id);
            if (lastName == null)
            {
                return NotFound();
            }

            return View(lastName);
        }

        // GET: LastName/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LastName/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LastNameID,LName")] LastName lastName)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lastName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lastName);
        }

        // GET: LastName/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lastName = await _context.LastNames.FindAsync(id);
            if (lastName == null)
            {
                return NotFound();
            }
            return View(lastName);
        }

        // POST: LastName/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LastNameID,LName")] LastName lastName)
        {
            if (id != lastName.LastNameID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lastName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LastNameExists(lastName.LastNameID))
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
            return View(lastName);
        }

        // GET: LastName/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lastName = await _context.LastNames
                .FirstOrDefaultAsync(m => m.LastNameID == id);
            if (lastName == null)
            {
                return NotFound();
            }

            return View(lastName);
        }

        // POST: LastName/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lastName = await _context.LastNames.FindAsync(id);
            _context.LastNames.Remove(lastName);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LastNameExists(int id)
        {
            return _context.LastNames.Any(e => e.LastNameID == id);
        }
    }
}
