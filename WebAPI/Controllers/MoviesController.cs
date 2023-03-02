using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using WebAPI.Models;
using WebAPI.Models.DTOs;
using WebAPI.Services.MovieService;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _service;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        {
            return Ok(_mapper.Map<IEnumerable<MovieReadDTO>>(await _service.GetAllMovies()));
        }
        //// GET: Movies
        //public async Task<IActionResult> Index()
        //{
        //    var moviesDbContext = _context.Movie.Include(m => m.Franchise);
        //    return View(await moviesDbContext.ToListAsync());
        //}

        //// GET: Movies/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Movie == null)
        //    {
        //        return NotFound();
        //    }

        //    var movie = await _context.Movie
        //        .Include(m => m.Franchise)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(movie);
        //}

        //// GET: Movies/Create
        //public IActionResult Create()
        //{
        //    ViewData["FranchiseId"] = new SelectList(_context.Franchise, "Id", "Name");
        //    return View();
        //}

        //// POST: Movies/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Title,Genre,ReleaseYear,Director,PosterURL,TrailerURL,FranchiseId")] Movie movie)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(movie);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["FranchiseId"] = new SelectList(_context.Franchise, "Id", "Name", movie.FranchiseId);
        //    return View(movie);
        //}

        //// GET: Movies/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Movie == null)
        //    {
        //        return NotFound();
        //    }

        //    var movie = await _context.Movie.FindAsync(id);
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["FranchiseId"] = new SelectList(_context.Franchise, "Id", "Name", movie.FranchiseId);
        //    return View(movie);
        //}

        //// POST: Movies/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,ReleaseYear,Director,PosterURL,TrailerURL,FranchiseId")] Movie movie)
        //{
        //    if (id != movie.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(movie);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!MovieExists(movie.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["FranchiseId"] = new SelectList(_context.Franchise, "Id", "Name", movie.FranchiseId);
        //    return View(movie);
        //}

        //// GET: Movies/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Movie == null)
        //    {
        //        return NotFound();
        //    }

        //    var movie = await _context.Movie
        //        .Include(m => m.Franchise)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(movie);
        //}

        //// POST: Movies/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Movie == null)
        //    {
        //        return Problem("Entity set 'MoviesDbContext.Movie'  is null.");
        //    }
        //    var movie = await _context.Movie.FindAsync(id);
        //    if (movie != null)
        //    {
        //        _context.Movie.Remove(movie);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool MovieExists(int id)
        //{
        //  return _context.Movie.Any(e => e.Id == id);
        //}
    }
}
