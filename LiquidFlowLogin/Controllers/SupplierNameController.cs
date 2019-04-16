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
    public class SupplierNameController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SupplierNameController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SupplierName
        public async Task<IActionResult> Index()
        {
            return View(await _context.SupplierNames.ToListAsync());
        }

        // GET: SupplierName/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierName = await _context.SupplierNames
                .FirstOrDefaultAsync(m => m.SupplierNameID == id);
            if (supplierName == null)
            {
                return NotFound();
            }

            return View(supplierName);
        }

        // GET: SupplierName/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SupplierName/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierNameID,SupName")] SupplierName supplierName)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplierName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplierName);
        }

        // GET: SupplierName/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierName = await _context.SupplierNames.FindAsync(id);
            if (supplierName == null)
            {
                return NotFound();
            }
            return View(supplierName);
        }

        // POST: SupplierName/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierNameID,SupName")] SupplierName supplierName)
        {
            if (id != supplierName.SupplierNameID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplierName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierNameExists(supplierName.SupplierNameID))
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
            return View(supplierName);
        }

        // GET: SupplierName/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierName = await _context.SupplierNames
                .FirstOrDefaultAsync(m => m.SupplierNameID == id);
            if (supplierName == null)
            {
                return NotFound();
            }

            return View(supplierName);
        }

        // POST: SupplierName/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplierName = await _context.SupplierNames.FindAsync(id);
            _context.SupplierNames.Remove(supplierName);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierNameExists(int id)
        {
            return _context.SupplierNames.Any(e => e.SupplierNameID == id);
        }
    }
}
