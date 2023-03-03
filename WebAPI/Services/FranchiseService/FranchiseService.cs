using Microsoft.EntityFrameworkCore;
using WebAPI.Exceptions;
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

        /// <summary>
        /// The service of getting all the franchises in db.
        /// </summary>
        /// <returns>list of all franchises.</returns>
        public async Task<IEnumerable<Franchise>> GetAllFranchises()
        {
            return await _context.Franchises.ToListAsync();
        }

        /// <summary>
        /// The service of getting a franchise based on an id.
        /// </summary>
        /// <param name="id"> The unique id of an franchise.</param>
        /// <returns>The franchise of the unique id.</returns>
        /// <exception cref="FranchiseNotFoundException"> When the unique id is not in the db.</exception>
        public async Task<Franchise> GetFranchiseById(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);
            if (franchise == null)
            {
                throw new FranchiseNotFoundException(id);
            }
            return franchise;
        }

        /// <summary>
        /// The service for creating a new franchise for the db.
        /// </summary>
        /// <param name="franchise">An franchise (string Name, string Description)</param>
        /// <returns>Given franchise and post on db</returns>
        /// <exception cref="ArgumentNullException">When given franchise is null.</exception>
        public async Task<Franchise> CreateFranchise(Franchise franchise)
        {
            if (franchise == null) throw new ArgumentNullException(nameof(franchise));
            await _context.Franchises.AddAsync(franchise); 
            await _context.SaveChangesAsync();
            return franchise;
        }

        /// <summary>
        /// The service for deleting a franchise by id.
        /// </summary>
        /// <param name="id">Unique identifier of franchise.</param>
        /// <returns></returns>
        /// <exception cref="FranchiseNotFoundException">When cant find franchise by the unique identifier.</exception>
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
        /// <summary>
        /// The service for getting all movies in a franchise based on id.
        /// </summary>
        /// <param name="id">Unique identifer for franchise.</param>
        /// <returns>List of movies.</returns>
        /// <exception cref="FranchiseNotFoundException">When cant find franchise by the unique identifier.</exception>
        public async Task<IEnumerable<Movie>> GetAllFranchiseMovies(int id)
        {
            var franchiseExist = await _context.Franchises.FindAsync(id);
            if (franchiseExist == null) throw new FranchiseNotFoundException(id);
           var franchise = await _context.Franchises
                .Include(f => f.Movies)
                .Where(m => m.Id==id)
                .FirstOrDefaultAsync();
            return franchise.Movies;
        }

        /// <summary>
        /// The service for getting all character in every movie of a franchise.
        /// </summary>
        /// <param name="id">Unique identifer for franchise.</param>
        /// <returns>List of characters.</returns>
        /// <exception cref="FranchiseNotFoundException">When cant find franchise by the unique identifier.</exception>
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
        /// <summary>
        /// The service to update an existing franchise.
        /// </summary>
        /// <param name="franchise"></param>
        /// <returns></returns>
        /// <exception cref="FranchiseNotFoundException">When cant find franchise by the unique identifier.></exception>
        public async Task<Franchise> UpdateFranchise(Franchise franchise)
        {
            var foundFranchise = await _context.Franchises.AnyAsync(x => x.Id == franchise.Id);
            if (!foundFranchise) throw new FranchiseNotFoundException(franchise.Id);
            _context.Entry(franchise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return franchise;
        }
        /// <summary>
        /// The service for updating the list of movies to an existing franchise based on a id.
        /// </summary>
        /// <param name="id">Unique identifer for franchise.</param>
        /// <param name="moviesId">unique list of identities of existing movies.</param>
        /// <returns></returns>
        /// <exception cref="FranchiseNotFoundException">When a identifier of a franchise cant be found.</exception>
        /// <exception cref="MovieNotFoundException">When a identifier of a movie cant be found.</exception>
        public async Task UpdateFranchiseMovies(int id, List<int> moviesId)
        {
            var foundFranchise = await _context.Franchises.AnyAsync(franchise => franchise.Id == id);
            if (!foundFranchise)
            {
                throw new FranchiseNotFoundException(id);
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
                    throw new MovieNotFoundException(Id);
                movies.Add(movie);
            }
            franchiseToUpdateMovies.Movies = movies;
            _context.Entry(franchiseToUpdateMovies).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
