using WebAPI.Models;
using WebAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services.MovieService
{
    public class MovieService : IMovieService
    {
        #region Constructor & Fields
        private readonly MoviesDbContext _context;

        public MovieService(MoviesDbContext context)
        {
            _context = context;
        }
        #endregion

        /// <summary>
        /// Adds a movie to the database.
        /// </summary>
        /// <param name="movie">Movie object</param>
        /// <returns>Movie object added to database via Task</returns>
        public async Task<Movie> AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        /// <summary>
        /// Deletes a movie from the database by ID.
        /// </summary>
        /// <param name="id">Identifier of movie to delete</param>
        /// <returns>Deleted movie via Task</returns>
        /// <exception cref="MovieNotFoundException"></exception>
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

        /// <summary>
        /// Gets all characters in a movie specified by ID.
        /// </summary>
        /// <param name="id">Identifier of movie to get characters from.</param>
        /// <returns>Characters in movie</returns>
        public async Task<IEnumerable<Character>> GetAllMovieCharacters(int id)
        {
            try
            {
                bool movieExists = await _context.Movies.AnyAsync(movie => movie.Id == id);

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

        /// <summary>
        /// Gets all movies from database.
        /// </summary>
        /// <returns>All movies in database</returns>
        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            try
            {
                return await _context.Movies.Include(movie => movie.Characters).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Gets a movie from database by ID.
        /// </summary>
        /// <param name="id">Identifier of movie to get</param>
        /// <returns>Movie</returns>
        /// <exception cref="MovieNotFoundException"></exception>
        public async Task<Movie> GetMovieById(int id)
        {

            var movie = await _context.Movies.Include(movie => movie.Characters).FirstOrDefaultAsync(x => x.Id == id);

            if (movie == null)
            {
                throw new MovieNotFoundException(id);
            }

            return movie;
        }

        /// <summary>
        /// Updates a movie.
        /// </summary>
        /// <param name="movie">Movie to be updated</param>
        /// <returns>Updated movie by task</returns>
        /// <exception cref="MovieNotFoundException"></exception>
        public async Task<Movie> UpdateMovie(Movie movie)
        {
            var foundMovie = await _context.Movies.AnyAsync(m => m.Id == movie.Id);
            
            if (!foundMovie)
            {
                throw new MovieNotFoundException(movie.Id);
            }
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return movie;
        }

        /// <summary>
        /// Updates characters in a movie.
        /// </summary>
        /// <param name="id">Identifier of movie</param>
        /// <param name="charactersId">List of IDs of characters to be added</param>
        /// <returns>Updated movie via Task</returns>
        /// <exception cref="MovieNotFoundException"></exception>
        /// <exception cref="KeyNotFoundException"></exception>
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
