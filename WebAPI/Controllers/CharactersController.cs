using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Exceptions;
using WebAPI.Models;
using WebAPI.Models.DTOs.Characters;
using WebAPI.Services.CharacterService;

namespace WebAPI.Controllers
{
    // Annotations specifiying where the controller is located,
    // that it should be controlled by API,
    // that it creates and uses JSONs,
    // and that it uses the defualt API conventions.
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CharactersController : ControllerBase
    {
        #region Fields & Constructor
        private readonly ICharacterService _service;
        private readonly IMapper _mapper;

        // Sets the service and mapper for this controller via constructor.
        public CharactersController(ICharacterService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        #endregion
        #region HTTP Gets
        /// <summary>
        /// Returns all characters in the database.
        /// </summary>
        /// <returns>All characters in database</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            try { 
                return Ok(_mapper.Map<IEnumerable<CharacterReadDTO>>(await _service.GetAllCharacters()));
            }
            catch (CharacterNotFoundException e)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = e.Message
                });
            }
        }

        /// <summary>
        /// Gets a specific character by ID.
        /// </summary>
        /// <param name="id">Character identifier</param>
        /// <returns>A specific character</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            try
            {
                return Ok(_mapper.Map<CharacterReadDTO>(await _service.GetCharacterById(id)));
            }
            catch (CharacterNotFoundException e)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = e.Message
                });
            }
        }
        #endregion
        #region HTTP Puts
        /// <summary>
        /// Updates fields of a character specified by ID, with new object data values.
        /// </summary>
        /// <param name="id">Character identifier</param>
        /// <param name="characterDTO">New character DTO</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterUpdateDTO characterDTO)
        {
            try
            {
                var character = _mapper.Map<Character>(characterDTO);
                character.Id = id;
                await _service.UpdateCharacter(character);
            }
            catch (CharacterNotFoundException e)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = e.Message
                });
            }

            return NoContent();
        }
        #endregion
        #region HTTP Posts
        /// <summary>
        /// Creates character in the database.
        /// </summary>
        /// <param name="character">New character DTO</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(CharacterUpdateDTO characterDTO)
        {
            var character = _mapper.Map<Character>(characterDTO);
            return CreatedAtAction("GetCharacter", new { id = character.Id }, await _service.AddCharacter(character));
        }
        #endregion
        #region HTTP Deletes
        /// <summary>
        /// Deletes a character by ID.
        /// </summary>
        /// <param name="id">Character identifier</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            try
            {
                await _service.DeleteCharacter(id);
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }
        #endregion
    }
}
