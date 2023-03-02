using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class FranchisesController : Controller
    {
        private readonly MoviesDbContext _context;

        public FranchisesController(MoviesDbContext context)
        {
            _context = context;
        }

        // GET: Franchises
        public async Task<IActionResult> Index()
        {
              return View(await _context.Franchises.ToListAsync());
        }

        // GET: Franchises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Franchises == null)
            {
                return NotFound();
            }

            var franchise = await _context.Franchises
                .FirstOrDefaultAsync(m => m.Id == id);
            if (franchise == null)
            {
                return NotFound();
            }

            return View(franchise);
        }

        // GET: Franchises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Franchises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Franchise franchise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(franchise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(franchise);
        }

        // GET: Franchises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Franchises == null)
            {
                return NotFound();
            }

            var franchise = await _context.Franchises.FindAsync(id);
            if (franchise == null)
            {
                return NotFound();
            }
            return View(franchise);
        }

        // POST: Franchises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Franchise franchise)
        {
            if (id != franchise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(franchise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FranchiseExists(franchise.Id))
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
            return View(franchise);
        }

        // GET: Franchises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Franchises == null)
            {
                return NotFound();
            }

            var franchise = await _context.Franchises
                .FirstOrDefaultAsync(m => m.Id == id);
            if (franchise == null)
            {
                return NotFound();
            }

            return View(franchise);
        }

        // POST: Franchises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Franchises == null)
            {
                return Problem("Entity set 'MoviesDbContext.Franchises'  is null.");
            }
            var franchise = await _context.Franchises.FindAsync(id);
            if (franchise != null)
            {
                _context.Franchises.Remove(franchise);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FranchiseExists(int id)
        {
          return _context.Franchises.Any(e => e.Id == id);
        }
    }
}
