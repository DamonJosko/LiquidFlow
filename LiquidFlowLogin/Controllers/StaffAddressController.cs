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
    public class StaffAddressController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffAddressController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StaffAddress
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StaffAddresses.Include(s => s.Address).Include(s => s.Staff);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StaffAddress/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffAddress = await _context.StaffAddresses
                .Include(s => s.Address)
                .Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.StaffID == id);
            if (staffAddress == null)
            {
                return NotFound();
            }

            return View(staffAddress);
        }

        // GET: StaffAddress/Create
        public IActionResult Create()
        {
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID");
            ViewData["StaffID"] = new SelectList(_context.StaffMemebers, "StaffID", "StaffID");
            return View();
        }

        // POST: StaffAddress/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffID,AddressID")] StaffAddress staffAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID", staffAddress.AddressID);
            ViewData["StaffID"] = new SelectList(_context.StaffMemebers, "StaffID", "StaffID", staffAddress.StaffID);
            return View(staffAddress);
        }

        // GET: StaffAddress/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffAddress = await _context.StaffAddresses.FindAsync(id);
            if (staffAddress == null)
            {
                return NotFound();
            }
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID", staffAddress.AddressID);
            ViewData["StaffID"] = new SelectList(_context.StaffMemebers, "StaffID", "StaffID", staffAddress.StaffID);
            return View(staffAddress);
        }

        // POST: StaffAddress/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffID,AddressID")] StaffAddress staffAddress)
        {
            if (id != staffAddress.StaffID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffAddressExists(staffAddress.StaffID))
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
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID", staffAddress.AddressID);
            ViewData["StaffID"] = new SelectList(_context.StaffMemebers, "StaffID", "StaffID", staffAddress.StaffID);
            return View(staffAddress);
        }

        // GET: StaffAddress/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffAddress = await _context.StaffAddresses
                .Include(s => s.Address)
                .Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.StaffID == id);
            if (staffAddress == null)
            {
                return NotFound();
            }

            return View(staffAddress);
        }

        // POST: StaffAddress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffAddress = await _context.StaffAddresses.FindAsync(id);
            _context.StaffAddresses.Remove(staffAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffAddressExists(int id)
        {
            return _context.StaffAddresses.Any(e => e.StaffID == id);
        }
    }
}
