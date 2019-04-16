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
    public class ZIPController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZIPController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ZIP
        public async Task<IActionResult> Index()
        {
            return View(await _context.ZIPs.ToListAsync());
        }

        // GET: ZIP/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zIP = await _context.ZIPs
                .FirstOrDefaultAsync(m => m.ZIPID == id);
            if (zIP == null)
            {
                return NotFound();
            }

            return View(zIP);
        }

        // GET: ZIP/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZIP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZIPID,ZIPCode")] ZIP zIP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zIP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zIP);
        }

        // GET: ZIP/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zIP = await _context.ZIPs.FindAsync(id);
            if (zIP == null)
            {
                return NotFound();
            }
            return View(zIP);
        }

        // POST: ZIP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZIPID,ZIPCode")] ZIP zIP)
        {
            if (id != zIP.ZIPID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zIP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZIPExists(zIP.ZIPID))
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
            return View(zIP);
        }

        // GET: ZIP/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zIP = await _context.ZIPs
                .FirstOrDefaultAsync(m => m.ZIPID == id);
            if (zIP == null)
            {
                return NotFound();
            }

            return View(zIP);
        }

        // POST: ZIP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zIP = await _context.ZIPs.FindAsync(id);
            _context.ZIPs.Remove(zIP);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZIPExists(int id)
        {
            return _context.ZIPs.Any(e => e.ZIPID == id);
        }
    }
}
