
using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Exceptions;
using WebAPI.Models;
using WebAPI.Models.DTOs.Characters;
using WebAPI.Models.DTOs.Franchises;
using WebAPI.Models.DTOs.Movies;
using WebAPI.Services.FranchiseService;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class FranchisesController : ControllerBase
    {
        private readonly IFranchiseService _franchiseService;
        private readonly IMapper _mapper;

        public FranchisesController(IFranchiseService franchiseService, IMapper mapper)
        {
            _franchiseService = franchiseService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all franchies in db.
        /// </summary>
        /// <returns>List of franchises.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseReadDTO>>> GetAllFranchises()
        {
            return Ok(_mapper.Map<IEnumerable<FranchiseReadDTO>>(await _franchiseService.GetAllFranchises()));
        }

        /// <summary>
        /// Get one franchise based on identifier.
        /// </summary>
        /// <param name="id">Unique identifer of a franchise.</param>
        /// <returns>One spicific franchise based on idenfier.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseReadDTO>> GetFranchiseById(int id)
        {
            try
            {
                return Ok(_mapper.Map<FranchiseReadDTO>(await _franchiseService.GetFranchiseById(id)));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }
        /// <summary>
        /// Create new franchise to db.
        /// </summary>
        /// <param name="createFranchiseDto">A franchise contain string Name and string Description.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Franchise>> CreateFranchise(FranchiseCreateDTO createFranchiseDto)
        {
            try
            {
                var franchise = _mapper.Map<Franchise>(createFranchiseDto);
                await _franchiseService.CreateFranchise(franchise);
                return CreatedAtAction(nameof(GetFranchiseById), new { id = franchise.Id }, franchise);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Delete one franchise from db based on a identifier.
        /// </summary>
        /// <param name="id">An unique identifier of a franchise.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            try
            {
                await _franchiseService.DeleteFranchise(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }

        /// <summary>
        /// Get all the movies for a given franchise.
        /// </summary>
        /// <param name="id">Unique identifier of a franchise.</param>
        /// <returns>A list of movies.</returns>
        [HttpGet("{id}/movies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllFranchiseMovies(int id)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<MovieReadDTO>>(await _franchiseService.GetAllFranchiseMovies(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Get all characters in every movie in a specific franchise.
        /// </summary>
        /// <param name="id">Unique identifier of a existing franchise.</param>
        /// <returns>List of characters.</returns>
        [HttpGet("{id}/movies/characters")]
        public async Task<ActionResult<IEnumerable<Character>>> GetAllFranchiseCharacters(int id)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<CharacterReadDTO>>(await _franchiseService.GetAllFranchiseCharacters(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update an existing franchise in db.
        /// </summary>
        /// <param name="id">Unique identifier of a franchise.</param>
        /// <param name="franchiseDTO">An franchise info, Name and description.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, FranchiseUpdateDTO franchiseDTO)
        {
            if (id != franchiseDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                var franchise = _mapper.Map<Franchise>(franchiseDTO);
                await _franchiseService.UpdateFranchise(franchise);
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }
        /// <summary>
        /// Update the movies of a specific franchise.
        /// </summary>
        /// <param name="id">Unique identifier of a franchise.</param>
        /// <param name="movies">List of existing movie identifiers.</param>
        /// <returns></returns>
        [HttpPut("{id}/movies")]
        public async Task<IActionResult> UpdateFranchiseMovies(int id, List<int> movies)
        {
            try
            {
                await _franchiseService.UpdateFranchiseMovies(id, movies);
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("Invalid character.");
            }

            return NoContent();
        }


    }
}
