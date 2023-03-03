using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPI.Exceptions;
using WebAPI.Models;
using WebAPI.Models.DTOs;
using WebAPI.Services.CharacterService;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _service;
        private readonly IMapper _mapper;
        public CharactersController(ICharacterService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns all characters in the database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            return Ok(_mapper.Map<IEnumerable<CharacterReadDTO>>(await _service.GetAllCharacters()));
        }

        /// <summary>
        /// Gets a specific character by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            try
            {
                return Ok(_mapper.Map<CharacterReadDTO>(await _service.GetCharacterById(id)));
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        /// <summary>
        /// Updates fields of a character specified by ID, with new object data values.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="characterDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterUpdateDTO characterDTO)
        {
            if (id != characterDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                var character = _mapper.Map<Character>(characterDTO);
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

        /// <summary>
        /// Creates character in the database.
        /// </summary>
        /// <param name="character
        /// "></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(CharacterUpdateDTO characterDto)
        {
            var character = _mapper.Map<Character>(characterDto);
            return CreatedAtAction("GetCharacter", new { id = character.Id }, await _service.AddCharacter(character));
        }

        /// <summary>
        /// Deletes a character by ID.
        /// </summary>
        /// <param name="id"></param>
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
    }
}
