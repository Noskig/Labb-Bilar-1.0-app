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
    public class StadsController : Controller
    {
        private readonly BilContext _context;

        public StadsController(BilContext context)
        {
            _context = context;
        }

        // GET: Stads
        public async Task<IActionResult> Index()
        {
            return View(await _context.Städer.ToListAsync());
        }

        // GET: Stads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stad = await _context.Städer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stad == null)
            {
                return NotFound();
            }

            return View(stad);
        }

        // GET: Stads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Namn")] Stad stad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stad);
        }

        // GET: Stads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stad = await _context.Städer.FindAsync(id);
            if (stad == null)
            {
                return NotFound();
            }
            return View(stad);
        }

        // POST: Stads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Namn")] Stad stad)
        {
            if (id != stad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StadExists(stad.Id))
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
            return View(stad);
        }

        // GET: Stads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stad = await _context.Städer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stad == null)
            {
                return NotFound();
            }

            return View(stad);
        }

        // POST: Stads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stad = await _context.Städer.FindAsync(id);
            _context.Städer.Remove(stad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StadExists(int id)
        {
            return _context.Städer.Any(e => e.Id == id);
        }
    }
}
