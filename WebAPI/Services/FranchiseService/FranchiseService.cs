using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

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

        public async Task<Franchise> CreateFranchise(Franchise franchise)
        {
            if (franchise == null) throw new ArgumentNullException(nameof(franchise));
            await _context.Franchises.AddAsync(franchise); 
            await _context.SaveChangesAsync();
            return franchise;
        }

        public Task DeleteFranchise(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Character>> GetAllFranchiseCharacters(int franchiseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetAllFranchiseMovies(int franchiseId)
        {
            throw new NotImplementedException();
        }

        public Task<Franchise> GetFranchiseById(int id)
        {
            throw new NotImplementedException();
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
