using WebAPI.Models;

namespace WebAPI.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        public Task<Character> AddCharacter(Character character)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCharacter(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Character>> GetAllCharacters()
        {
            throw new NotImplementedException();
        }

        public Task<Character> GetCharacterById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Character> UpdateCharacter(Character character)
        {
            throw new NotImplementedException();
        }
    }
}
