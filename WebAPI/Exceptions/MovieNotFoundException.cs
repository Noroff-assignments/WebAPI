namespace WebAPI.Exceptions
{
    public class MovieNotFoundException : Exception
    {
        public MovieNotFoundException(int id) : base($"Couldn't find movie with ID: {id}") { }
    }
}
