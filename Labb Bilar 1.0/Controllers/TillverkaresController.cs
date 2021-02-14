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
    public class TillverkaresController : Controller
    {
        private readonly BilContext _context;

        public TillverkaresController(BilContext context)
        {
            _context = context;
        }

        // GET: Tillverkares
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tillverkarna.ToListAsync());
        }

        // GET: Tillverkares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tillverkare = await _context.Tillverkarna
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tillverkare == null)
            {
                return NotFound();
            }

            return View(tillverkare);
        }

        // GET: Tillverkares/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tillverkares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Namn")] Tillverkare tillverkare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tillverkare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tillverkare);
        }

        // GET: Tillverkares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tillverkare = await _context.Tillverkarna.FindAsync(id);
            if (tillverkare == null)
            {
                return NotFound();
            }
            return View(tillverkare);
        }

        // POST: Tillverkares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Namn")] Tillverkare tillverkare)
        {
            if (id != tillverkare.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tillverkare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TillverkareExists(tillverkare.Id))
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
            return View(tillverkare);
        }

        // GET: Tillverkares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tillverkare = await _context.Tillverkarna
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tillverkare == null)
            {
                return NotFound();
            }

            return View(tillverkare);
        }

        // POST: Tillverkares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tillverkare = await _context.Tillverkarna.FindAsync(id);
            _context.Tillverkarna.Remove(tillverkare);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TillverkareExists(int id)
        {
            return _context.Tillverkarna.Any(e => e.Id == id);
        }
    }
}
