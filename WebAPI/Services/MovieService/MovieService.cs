using WebAPI.Models;

namespace WebAPI.Services.MovieService
{
    public class MovieService : IMovieService
    {
        public Task<Movie> AddMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Character>> GetAllMovieCharacters(int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetAllMovies()
        {
            throw new NotImplementedException();
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
