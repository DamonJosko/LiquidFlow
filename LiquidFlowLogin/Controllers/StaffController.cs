﻿using System;
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
    public class StaffController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Staff
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StaffMemebers.Include(s => s.FirstName).Include(s => s.LastName);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Staff/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.StaffMemebers
                .Include(s => s.FirstName)
                .Include(s => s.LastName)
                .FirstOrDefaultAsync(m => m.StaffID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Staff/Create
        public IActionResult Create()
        {
            ViewData["FirstNameID"] = new SelectList(_context.FirstNames, "FirstNameID", "FirstNameID");
            ViewData["LastNameID"] = new SelectList(_context.LastNames, "LastNameID", "LastNameID");
            return View();
        }

        // POST: Staff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffID,FirstNameID,LastNameID")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FirstNameID"] = new SelectList(_context.FirstNames, "FirstNameID", "FirstNameID", staff.FirstNameID);
            ViewData["LastNameID"] = new SelectList(_context.LastNames, "LastNameID", "LastNameID", staff.LastNameID);
            return View(staff);
        }

        // GET: Staff/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.StaffMemebers.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            ViewData["FirstNameID"] = new SelectList(_context.FirstNames, "FirstNameID", "FirstNameID", staff.FirstNameID);
            ViewData["LastNameID"] = new SelectList(_context.LastNames, "LastNameID", "LastNameID", staff.LastNameID);
            return View(staff);
        }

        // POST: Staff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffID,FirstNameID,LastNameID")] Staff staff)
        {
            if (id != staff.StaffID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.StaffID))
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
            ViewData["FirstNameID"] = new SelectList(_context.FirstNames, "FirstNameID", "FirstNameID", staff.FirstNameID);
            ViewData["LastNameID"] = new SelectList(_context.LastNames, "LastNameID", "LastNameID", staff.LastNameID);
            return View(staff);
        }

        // GET: Staff/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.StaffMemebers
                .Include(s => s.FirstName)
                .Include(s => s.LastName)
                .FirstOrDefaultAsync(m => m.StaffID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff = await _context.StaffMemebers.FindAsync(id);
            _context.StaffMemebers.Remove(staff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffExists(int id)
        {
            return _context.StaffMemebers.Any(e => e.StaffID == id);
        }
    }
}
