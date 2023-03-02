using WebAPI.Models;
using WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly MoviesDbContext _context;

        public MovieService(MoviesDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task DeleteMovie(int id)
        {
            Movie movie = await _context.Movies.FindAsync(id);

            if(movie == null)
            {
                throw new MovieNotFoundException(id);
            }
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Character>> GetAllMovieCharacters(int id)
        {
            try
            {
                bool movieExists = await _context.Movies.AnyAsync(x => x.Id == id);

                if (!movieExists)
                {
                    throw new MovieNotFoundException(id);
                }
            }
            catch (MovieNotFoundException e)
            {
                Console.WriteLine(e);
            }


            var movie = await _context.Movies.Include(movie => movie.Characters)
                        .Where(movie => movie.Id == id).FirstOrDefaultAsync();

            return movie.Characters;
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _context.Movies.Include(x => x.Characters).ToListAsync();
        }

        public Task<Movie> GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMovieCharacters(int id, List<int> characters)
        {
            throw new NotImplementedException();
        }
    }
}
