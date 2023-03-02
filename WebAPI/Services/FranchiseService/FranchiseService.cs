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
            var franchise = await _context.Franchises.FindAsync(id);
            if (franchise == null)
            {
                throw new FranchiseNotFoundException(id);
            }
            var movies =  await _context.Movies.Where(m => m.FranchiseId == id).ToListAsync();
            return movies;
        }

        public async Task<IEnumerable<Character>> GetAllFranchiseCharacters(int id)
        {
            throw new NotImplementedException();
            /*var franchise = await _context.Franchises.FindAsync(id);
            if (franchise == null)
            {
                throw new FranchiseNotFoundException(id);
            }
            var movies = await _context.Movies.Where(m => m.FranchiseId == id).ToListAsync();
            var character = await _context.Characters.Where(c => c.Id == movieid).ToListAsync();
            return character;*/
        }



        public Task<Franchise> UpdateFranchise(Franchise franchise)
        {
            throw new NotImplementedException();
        }

        public Task UpdateFranchiseMovies(int id, List<int> moviesId)
        {
            throw new NotImplementedException();
        }
    }
}
