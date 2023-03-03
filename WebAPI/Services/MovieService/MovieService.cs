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
            try
            {
                return await _context.Movies.Include(x => x.Characters).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Movie> GetMovieById(int id)
        {

            var movie = await _context.Movies.Include(x => x.Characters).FirstOrDefaultAsync(x => x.Id == id);

            if (movie == null)
            {
                throw new MovieNotFoundException(id);
            }

            return movie;
        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            var foundMovie = await _context.Movies.AnyAsync(x => x.Id == movie.Id);
            if (!foundMovie)
            {
                throw new MovieNotFoundException(movie.Id);
            }
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task UpdateMovieCharacters(int id, List<int> charactersId)
        {
            var foundMovie = await _context.Movies.AnyAsync(movie => movie.Id == id);
            if (!foundMovie)
            {
                throw new MovieNotFoundException(id);
            }

            var movieToUpdateCharacters = await _context.Movies
                .Include(m => m.Characters)
                .Where(m => m.Id == id)
                .FirstAsync();
          
            var characters = new List<Character>();

            foreach (int Id in charactersId)
            {
                var character = await _context.Characters.FindAsync(Id);
                if (character == null)
                    throw new KeyNotFoundException($"Couldn't find character with ID: {Id}");
                characters.Add(character);
            }
            movieToUpdateCharacters.Characters = characters;
            _context.Entry(movieToUpdateCharacters).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
