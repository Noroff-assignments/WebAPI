using Microsoft.EntityFrameworkCore;
using WebAPI.Exceptions;
using WebAPI.Models;

namespace WebAPI.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly MoviesDbContext _context;
        public CharacterService(MoviesDbContext context)
        {
            _context = context;
        }
        public async Task<Character> AddCharacter(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return character;
        }

        public async Task DeleteCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);

            if (character == null)
            {
                throw new CharacterNotFoundException(id);
            }
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Character>> GetAllCharacters()
        {
            return await _context.Characters.Include(c => c.Movies).ToListAsync();
        }

        public async Task<Character> GetCharacterById(int id)
        {
            var character = await _context.Characters.Include(c => c.Movies).FirstOrDefaultAsync(c => c.Id == id);

            if (character == null)
            {
                throw new CharacterNotFoundException(id);
            }

            return character;
        }

        public async Task<Character> UpdateCharacter(Character character)
        {
            var foundCharacter = await _context.Characters.AnyAsync(x => x.Id == character.Id);
            if (!foundCharacter)
            {
                throw new CharacterNotFoundException(character.Id);
            }
            _context.Entry(character).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return character;
        }
    }
}
