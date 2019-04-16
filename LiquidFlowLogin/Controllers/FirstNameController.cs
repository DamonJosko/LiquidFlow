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
    public class FirstNameController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FirstNameController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FirstName
        public async Task<IActionResult> Index()
        {
            return View(await _context.FirstNames.ToListAsync());
        }

        // GET: FirstName/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firstName = await _context.FirstNames
                .FirstOrDefaultAsync(m => m.FirstNameID == id);
            if (firstName == null)
            {
                return NotFound();
            }

            return View(firstName);
        }

        // GET: FirstName/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FirstName/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstNameID,FName")] FirstName firstName)
        {
            if (ModelState.IsValid)
            {
                _context.Add(firstName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(firstName);
        }

        // GET: FirstName/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firstName = await _context.FirstNames.FindAsync(id);
            if (firstName == null)
            {
                return NotFound();
            }
            return View(firstName);
        }

        // POST: FirstName/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstNameID,FName")] FirstName firstName)
        {
            if (id != firstName.FirstNameID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(firstName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FirstNameExists(firstName.FirstNameID))
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
            return View(firstName);
        }

        // GET: FirstName/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firstName = await _context.FirstNames
                .FirstOrDefaultAsync(m => m.FirstNameID == id);
            if (firstName == null)
            {
                return NotFound();
            }

            return View(firstName);
        }

        // POST: FirstName/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var firstName = await _context.FirstNames.FindAsync(id);
            _context.FirstNames.Remove(firstName);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FirstNameExists(int id)
        {
            return _context.FirstNames.Any(e => e.FirstNameID == id);
        }
    }
}
