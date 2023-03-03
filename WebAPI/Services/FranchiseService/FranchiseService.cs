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
        private readonly IMapper _mapper;

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
            if (id <= 0) throw new ArgumentException("Invalid franchise id");

            var franchise = await _context.Franchises
                .Include(f => f.Movies)
                .ThenInclude(m => m.Characters)
                .SingleOrDefaultAsync(f => f.Id == id);
            
            if (franchise == null) throw new FranchiseNotFoundException(id);

            var characters = franchise.Movies
                .SelectMany(m => m.Characters);

            return characters.ToListAsync();
        }





        public async Task<Franchise> UpdateFranchise(Franchise franchise)
        {
            throw new NotImplementedException();
            /*if (franchise == null) throw new ArgumentNullException(nameof(franchise));
            if (!await _franchiseRepository.FranchiseExistsAsync(franchise.Id)) throw new FranchiseNotFoundException(franchise.Id);


            _context.Entry(franchise).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return franchise;*/
        }




        public Task UpdateFranchiseMovies(int id, List<int> moviesId)
        {
            throw new NotImplementedException();
        }
    }
}
