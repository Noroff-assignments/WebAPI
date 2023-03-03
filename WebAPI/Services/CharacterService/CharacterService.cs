using Microsoft.EntityFrameworkCore;
using WebAPI.Exceptions;
using WebAPI.Models;

namespace WebAPI.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        #region Constructor & Fields
        private readonly MoviesDbContext _context;
        public CharacterService(MoviesDbContext context)
        {
            _context = context;
        }
        #endregion

        /// <summary>
        /// Adds a character to the database.
        /// </summary>
        /// <param name="character">Character object to add</param>
        /// <returns></returns>
        public async Task<Character> AddCharacter(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return character;
        }

        /// <summary>
        /// Deletes a character from the database, by ID.
        /// </summary>
        /// <param name="id">Identifier of character to delete</param>
        /// <returns></returns>
        /// <exception cref="CharacterNotFoundException"></exception>
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

        /// <summary>
        /// Gets all characters from the database.
        /// </summary>
        /// <returns>All characters in database</returns>
        public async Task<IEnumerable<Character>> GetAllCharacters()
        {
            return await _context.Characters.Include(character => character.Movies).ToListAsync();
        }

        /// <summary>
        /// Gets a character by ID
        /// </summary>
        /// <param name="id">Identifier of character</param>
        /// <returns>Specific character</returns>
        /// <exception cref="CharacterNotFoundException"></exception>
        public async Task<Character> GetCharacterById(int id)
        {
            var character = await _context.Characters.Include(character => character.Movies).FirstOrDefaultAsync(c => c.Id == id);

            if (character == null)
            {
                throw new CharacterNotFoundException(id);
            }

            return character;
        }

        /// <summary>
        /// Updates an existing character with new character properties
        /// </summary>
        /// <param name="character">Character object</param>
        /// <returns>Updated character via Task</returns>
        /// <exception cref="CharacterNotFoundException"></exception>
        public async Task<Character> UpdateCharacter(Character character)
        {
            var foundCharacter = await _context.Characters.AnyAsync(characer => character.Id == character.Id);
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
