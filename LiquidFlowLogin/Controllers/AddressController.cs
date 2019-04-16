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
    // This is from the Microsoft.AspNetCore.Authorization namespace which is part of the identity framework
    // This denies access to the controller unless there is an active session
    // If a user role or member has been set up then this could be used to only allow administrators access to the controller
    // [Authorize(Roles="Administrators")] is an example of how you would authorise a role
    [Authorize]

    // Public class called AddressController that derives from Controller
    // A controller is a base class for an MVC controller that supports views
    public class AddressController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddressController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Address
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Addresses.Include(a => a.City).Include(a => a.Country).Include(a => a.CountyState).Include(a => a.StreetName).Include(a => a.ZIP);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Address/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // Checks to see if id is equal to null
            if (id == null)
            {
                // If the id is null then NotFound(); is returned
                // NotFound(); is from the Microsoft.AspNetCore.Http.StatusCodes namespace and produces the Status404NotFound response
                return NotFound();
            }

            //If there is an id then each column is then selected and "included"
            var address = await _context.Addresses
                .Include(a => a.City)
                .Include(a => a.Country)
                .Include(a => a.CountyState)
                .Include(a => a.StreetName)
                .Include(a => a.ZIP)
                // This checks to make sure that the first tuple is equal to the id entered
                .FirstOrDefaultAsync(m => m.AddressID == id);
            if (address == null)
            {
                return NotFound();
            }
            // If the id doesnt equal null then var address is displayed to the user and the repective data that has been included
            return View(address);
        }

        // GET: Address/Create
        public IActionResult Create()
        {
            // As the fields in this table are foreign keys, they must be selected with the use of SelectList
            ViewData["CityID"] = new SelectList(_context.Cities, "CityID", "CityID");
            ViewData["CountryID"] = new SelectList(_context.Countries, "CountryID", "CountryID");
            ViewData["CountyStateID"] = new SelectList(_context.CountyStates, "CountyStateID", "CountyStateID");
            ViewData["StreetNameID"] = new SelectList(_context.StreetNames, "StreetNameID", "StreetNameID");
            ViewData["ZIPID"] = new SelectList(_context.ZIPs, "ZIPID", "ZIPID");
            return View();
        }

        // POST: Address/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // IActionResult is from the Microsoft.AspCoreNet.Mvc namespace
        // This binds the paramters to the HTTP and uses the POST method into the database
        public async Task<IActionResult> Create([Bind("AddressID,HouseNumber,StreetNameID,CityID,CountyStateID,ZIPID,CountryID")] Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Add(address);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityID"] = new SelectList(_context.Cities, "CityID", "CityID", address.CityID);
            ViewData["CountryID"] = new SelectList(_context.Countries, "CountryID", "CountryID", address.CountryID);
            ViewData["CountyStateID"] = new SelectList(_context.CountyStates, "CountyStateID", "CountyStateID", address.CountyStateID);
            ViewData["StreetNameID"] = new SelectList(_context.StreetNames, "StreetNameID", "StreetNameID", address.StreetNameID);
            ViewData["ZIPID"] = new SelectList(_context.ZIPs, "ZIPID", "ZIPID", address.ZIPID);
            return View(address);
        }

        // GET: Address/Edit/5
        // IActionResult is from the Microsoft.AspNetCore.Mvc namespace
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            ViewData["CityID"] = new SelectList(_context.Cities, "CityID", "CityID", address.CityID);
            ViewData["CountryID"] = new SelectList(_context.Countries, "CountryID", "CountryID", address.CountryID);
            ViewData["CountyStateID"] = new SelectList(_context.CountyStates, "CountyStateID", "CountyStateID", address.CountyStateID);
            ViewData["StreetNameID"] = new SelectList(_context.StreetNames, "StreetNameID", "StreetNameID", address.StreetNameID);
            ViewData["ZIPID"] = new SelectList(_context.ZIPs, "ZIPID", "ZIPID", address.ZIPID);
            return View(address);
        }

        // POST: Address/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddressID,HouseNumber,StreetNameID,CityID,CountyStateID,ZIPID,CountryID")] Address address)
        {
            if (id != address.AddressID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                // This is used to make sure that the correct amount of data has been added
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.AddressID))
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
            ViewData["CityID"] = new SelectList(_context.Cities, "CityID", "CityID", address.CityID);
            ViewData["CountryID"] = new SelectList(_context.Countries, "CountryID", "CountryID", address.CountryID);
            ViewData["CountyStateID"] = new SelectList(_context.CountyStates, "CountyStateID", "CountyStateID", address.CountyStateID);
            ViewData["StreetNameID"] = new SelectList(_context.StreetNames, "StreetNameID", "StreetNameID", address.StreetNameID);
            ViewData["ZIPID"] = new SelectList(_context.ZIPs, "ZIPID", "ZIPID", address.ZIPID);
            return View(address);
        }

        // GET: Address/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .Include(a => a.City)
                .Include(a => a.Country)
                .Include(a => a.CountyState)
                .Include(a => a.StreetName)
                .Include(a => a.ZIP)
                .FirstOrDefaultAsync(m => m.AddressID == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(e => e.AddressID == id);
        }
    }
}
