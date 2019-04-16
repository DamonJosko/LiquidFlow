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
    public class DeliveryVehicleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeliveryVehicleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeliveryVehicle
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DeliveryVehicles.Include(d => d.Status);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DeliveryVehicle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryVehicle = await _context.DeliveryVehicles
                .Include(d => d.Status)
                .FirstOrDefaultAsync(m => m.DeliveryVehicleID == id);
            if (deliveryVehicle == null)
            {
                return NotFound();
            }

            return View(deliveryVehicle);
        }

        // GET: DeliveryVehicle/Create
        public IActionResult Create()
        {
            ViewData["StatusID"] = new SelectList(_context.Statuses, "StatusID", "StatusID");
            return View();
        }

        // POST: DeliveryVehicle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeliveryVehicleID,VehicleRegistration,StatusID")] DeliveryVehicle deliveryVehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deliveryVehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StatusID"] = new SelectList(_context.Statuses, "StatusID", "StatusID", deliveryVehicle.StatusID);
            return View(deliveryVehicle);
        }

        // GET: DeliveryVehicle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryVehicle = await _context.DeliveryVehicles.FindAsync(id);
            if (deliveryVehicle == null)
            {
                return NotFound();
            }
            ViewData["StatusID"] = new SelectList(_context.Statuses, "StatusID", "StatusID", deliveryVehicle.StatusID);
            return View(deliveryVehicle);
        }

        // POST: DeliveryVehicle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeliveryVehicleID,VehicleRegistration,StatusID")] DeliveryVehicle deliveryVehicle)
        {
            if (id != deliveryVehicle.DeliveryVehicleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryVehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryVehicleExists(deliveryVehicle.DeliveryVehicleID))
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
            ViewData["StatusID"] = new SelectList(_context.Statuses, "StatusID", "StatusID", deliveryVehicle.StatusID);
            return View(deliveryVehicle);
        }

        // GET: DeliveryVehicle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryVehicle = await _context.DeliveryVehicles
                .Include(d => d.Status)
                .FirstOrDefaultAsync(m => m.DeliveryVehicleID == id);
            if (deliveryVehicle == null)
            {
                return NotFound();
            }

            return View(deliveryVehicle);
        }

        // POST: DeliveryVehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deliveryVehicle = await _context.DeliveryVehicles.FindAsync(id);
            _context.DeliveryVehicles.Remove(deliveryVehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryVehicleExists(int id)
        {
            return _context.DeliveryVehicles.Any(e => e.DeliveryVehicleID == id);
        }
    }
}
