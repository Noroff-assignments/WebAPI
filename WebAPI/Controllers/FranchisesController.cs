using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Models.DTOs.Franchises;
using WebAPI.Services.FranchiseService;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class FranchisesController : ControllerBase
    {
        private readonly IFranchiseService _franchiseService;
        private readonly IMapper _mapper;

        public FranchisesController(IFranchiseService franchiseService, IMapper mapper)
        {
            _franchiseService = franchiseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseReadDTO>>> GetAllFranchises()
        {
            return Ok(_mapper.Map<IEnumerable<FranchiseReadDTO>>(await _franchiseService.GetAllFranchises()));
        }

        /*
        // GET: Franchises
        public async Task<IActionResult> Index()
        {
              return View(await _context.Franchise.ToListAsync());
        }

        // GET: Franchises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Franchise == null)
            {
                return NotFound();
            }

            var franchise = await _context.Franchise
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
            if (id == null || _context.Franchise == null)
            {
                return NotFound();
            }

            var franchise = await _context.Franchise.FindAsync(id);
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
            if (id == null || _context.Franchise == null)
            {
                return NotFound();
            }

            var franchise = await _context.Franchise
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
            if (_context.Franchise == null)
            {
                return Problem("Entity set 'MoviesDbContext.Franchise'  is null.");
            }
            var franchise = await _context.Franchise.FindAsync(id);
            if (franchise != null)
            {
                _context.Franchise.Remove(franchise);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FranchiseExists(int id)
        {
          return _context.Franchise.Any(e => e.Id == id);
        } */
    }
}
