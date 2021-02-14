using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labb_Bilar_1._0.Data;
using Labb_Bilar_1._0.Models;

namespace Labb_Bilar_1._0.Controllers
{
    public class BilsController : Controller
    {
        private readonly BilContext _context;

        public BilsController(BilContext context)
        {
            _context = context;
        }

        // GET: Bils
        public async Task<IActionResult> Index()
        {
            var bilContext = _context.Bilar.Include(b => b.Tillverkare);
            return View(await bilContext.ToListAsync());
        }

        // GET: Bils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bil = await _context.Bilar
                .Include(b => b.Tillverkare)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bil == null)
            {
                return NotFound();
            }

            return View(bil);
        }

        // GET: Bils/Create
        public IActionResult Create()
        {
            ViewData["TillverkareId"] = new SelectList(_context.Tillverkarna, "Id", "Namn");
            return View();
        }

        // POST: Bils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Årsmodell,Motortyp,TillverkareId,Modell")] Bil bil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TillverkareId"] = new SelectList(_context.Tillverkarna, "Id", "Namn", bil.TillverkareId);
            return View(bil);
        }

        // GET: Bils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bil = await _context.Bilar.FindAsync(id);
            if (bil == null)
            {
                return NotFound();
            }
            ViewData["TillverkareId"] = new SelectList(_context.Tillverkarna, "Id", "Namn", bil.TillverkareId);
            return View(bil);
        }

        // POST: Bils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Årsmodell,Motortyp,TillverkareId,Modell")] Bil bil)
        {
            if (id != bil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BilExists(bil.Id))
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
            ViewData["TillverkareId"] = new SelectList(_context.Tillverkarna, "Id", "Namn", bil.TillverkareId);
            return View(bil);
        }

        // GET: Bils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bil = await _context.Bilar
                .Include(b => b.Tillverkare)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bil == null)
            {
                return NotFound();
            }

            return View(bil);
        }

        // POST: Bils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bil = await _context.Bilar.FindAsync(id);
            _context.Bilar.Remove(bil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BilExists(int id)
        {
            return _context.Bilar.Any(e => e.Id == id);
        }
    }
}
