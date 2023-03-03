namespace WebAPI.Exceptions
{
    public class MovieNotFoundException : Exception
    {
        // Exception used in case of not finding a specific movie.
        public MovieNotFoundException(int id) : base($"Couldn't find movie with ID: {id}") { }
    }
}
