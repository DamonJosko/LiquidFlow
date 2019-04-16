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
    public class CompanyAddressController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyAddressController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompanyAddress
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CompanyAddresses.Include(c => c.Address).Include(c => c.Company);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CompanyAddress/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyAddress = await _context.CompanyAddresses
                .Include(c => c.Address)
                .Include(c => c.Company)
                .FirstOrDefaultAsync(m => m.CompanyID == id);
            if (companyAddress == null)
            {
                return NotFound();
            }

            return View(companyAddress);
        }

        // GET: CompanyAddress/Create
        public IActionResult Create()
        {
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID");
            ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyID");
            return View();
        }

        // POST: CompanyAddress/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyID,AddressID")] CompanyAddress companyAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID", companyAddress.AddressID);
            ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyID", companyAddress.CompanyID);
            return View(companyAddress);
        }

        // GET: CompanyAddress/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyAddress = await _context.CompanyAddresses.FindAsync(id);
            if (companyAddress == null)
            {
                return NotFound();
            }
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID", companyAddress.AddressID);
            ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyID", companyAddress.CompanyID);
            return View(companyAddress);
        }

        // POST: CompanyAddress/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyID,AddressID")] CompanyAddress companyAddress)
        {
            if (id != companyAddress.CompanyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyAddressExists(companyAddress.CompanyID))
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
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID", companyAddress.AddressID);
            ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyID", companyAddress.CompanyID);
            return View(companyAddress);
        }

        // GET: CompanyAddress/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyAddress = await _context.CompanyAddresses
                .Include(c => c.Address)
                .Include(c => c.Company)
                .FirstOrDefaultAsync(m => m.CompanyID == id);
            if (companyAddress == null)
            {
                return NotFound();
            }

            return View(companyAddress);
        }

        // POST: CompanyAddress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyAddress = await _context.CompanyAddresses.FindAsync(id);
            _context.CompanyAddresses.Remove(companyAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyAddressExists(int id)
        {
            return _context.CompanyAddresses.Any(e => e.CompanyID == id);
        }
    }
}
