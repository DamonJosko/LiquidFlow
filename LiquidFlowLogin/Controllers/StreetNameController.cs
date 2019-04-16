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
    public class StreetNameController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StreetNameController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StreetName
        public async Task<IActionResult> Index()
        {
            return View(await _context.StreetNames.ToListAsync());
        }

        // GET: StreetName/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var streetName = await _context.StreetNames
                .FirstOrDefaultAsync(m => m.StreetNameID == id);
            if (streetName == null)
            {
                return NotFound();
            }

            return View(streetName);
        }

        // GET: StreetName/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StreetName/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StreetNameID,StrName")] StreetName streetName)
        {
            if (ModelState.IsValid)
            {
                _context.Add(streetName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(streetName);
        }

        // GET: StreetName/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var streetName = await _context.StreetNames.FindAsync(id);
            if (streetName == null)
            {
                return NotFound();
            }
            return View(streetName);
        }

        // POST: StreetName/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StreetNameID,StrName")] StreetName streetName)
        {
            if (id != streetName.StreetNameID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(streetName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StreetNameExists(streetName.StreetNameID))
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
            return View(streetName);
        }

        // GET: StreetName/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var streetName = await _context.StreetNames
                .FirstOrDefaultAsync(m => m.StreetNameID == id);
            if (streetName == null)
            {
                return NotFound();
            }

            return View(streetName);
        }

        // POST: StreetName/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var streetName = await _context.StreetNames.FindAsync(id);
            _context.StreetNames.Remove(streetName);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StreetNameExists(int id)
        {
            return _context.StreetNames.Any(e => e.StreetNameID == id);
        }
    }
}
