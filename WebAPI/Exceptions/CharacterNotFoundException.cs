namespace WebAPI.Exceptions
{
    public class CharacterNotFoundException : Exception
    {
        public CharacterNotFoundException(int id) : base($"Couldn't find character with ID: {id}") { }
    }
}
