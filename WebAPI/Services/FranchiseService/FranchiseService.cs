using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.Exceptions;
using WebAPI.Models;
using WebAPI.Models.DTOs;
using WebAPI.Models.DTOs.Franchises;

namespace WebAPI.Services.FranchiseService
{
    public class FranchiseService : IFranchiseService
    {

        private readonly MoviesDbContext _context;

        public FranchiseService(MoviesDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Franchise>> GetAllFranchises()
        {
            return await _context.Franchises.ToListAsync();
        }

        public async Task<Franchise> GetFranchiseById(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);
            if (franchise == null)
            {
                throw new FranchiseNotFoundException(id);
            }
            return franchise;
        }

        public async Task<Franchise> CreateFranchise(Franchise franchise)
        {
            if (franchise == null) throw new ArgumentNullException(nameof(franchise));
            await _context.Franchises.AddAsync(franchise); 
            await _context.SaveChangesAsync();
            return franchise;
        }

        public async Task DeleteFranchise(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);
            if (franchise == null)
            {
                throw new FranchiseNotFoundException(id);
            }

            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> GetAllFranchiseMovies(int id)
        {
            var franchiseExist = await _context.Franchises.FindAsync(id);
            if (franchiseExist == null) throw new FranchiseNotFoundException(id);
           var franchise = await _context.Franchises.Include(franchise => franchise.Movies).FirstOrDefaultAsync();
            return franchise.Movies;
        }

        public async Task<IEnumerable<Character>> GetAllFranchiseCharacters(int id)
        {
            var franchise = await _context.Franchises
                .Include(f => f.Movies)
                .ThenInclude(f => f.Characters)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (franchise == null) throw new FranchiseNotFoundException(id);

            var characters = franchise.Movies
                .SelectMany(m => m.Characters)
                .Distinct()
                .ToList();

            return characters;
        }

        public async Task<Franchise> UpdateFranchise(Franchise franchise)
        {
            var foundFranchise = await _context.Franchises.AnyAsync(x => x.Id == franchise.Id);
            if (!foundFranchise) throw new MovieNotFoundException(franchise.Id);
            _context.Entry(franchise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return franchise;
        }

        public async Task UpdateFranchiseMovies(int id, List<int> moviesId)
        {
            var foundFranchise = await _context.Franchises.AnyAsync(franchise => franchise.Id == id);
            if (!foundFranchise)
            {
                throw new MovieNotFoundException(id);
            }

            var franchiseToUpdateMovies = await _context.Franchises
                .Include(f => f.Movies)
                .Where(f => f.Id == id)
                .FirstAsync();

            var movies = new List<Movie>();

            foreach (var Id in moviesId)
            {
                var movie = await _context.Movies.FindAsync(Id);
                if (movie == null)
                    throw new KeyNotFoundException($"Couldn't find movie with ID: {Id}");
                movies.Add(movie);
            }
            franchiseToUpdateMovies.Movies = movies;
            _context.Entry(franchiseToUpdateMovies).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
