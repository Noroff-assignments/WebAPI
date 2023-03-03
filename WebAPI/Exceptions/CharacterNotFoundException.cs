namespace WebAPI.Exceptions
{
    public class CharacterNotFoundException : Exception
    {
        // Exception used in case of not finding a specific character.
        public CharacterNotFoundException(int id) : base($"Couldn't find character with ID: {id}") { }
    }
}
