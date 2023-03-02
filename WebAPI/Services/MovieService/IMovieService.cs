using WebAPI.Models;

namespace WebAPI.Services.MovieService
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(int id);
        Task<Movie> AddMovie(Movie movie);
        Task DeleteMovie(int id);
        Task<Movie> UpdateMovie(Movie movie);
        Task UpdateMovieCharacters(int id, List<int> characters);
        Task<IEnumerable<Character>> GetAllMovieCharacters(int movieId);
    }
}
