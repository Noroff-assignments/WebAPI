
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
    // Annotations specifiying where the controller is located,
    // that it should be controlled by API,
    // that it creates and uses JSONs,
    // and that it uses the defualt API conventions.
    [Route("api/v1/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class FranchisesController : ControllerBase
    {
        #region Fields & Constructor
        private readonly IFranchiseService _service;
        private readonly IMapper _mapper;

        // Sets the service and mapper for this controller via constructor.
        public FranchisesController(IFranchiseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        #endregion
        #region HTTP Gets
        /// <summary>
        /// Gets all franchises from database.
        /// </summary>
        /// <returns>List of franchises.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseReadDTO>>> GetAllFranchises()
        {
            try
            { 
                return Ok(_mapper.Map<IEnumerable<FranchiseReadDTO>>(await _service.GetAllFranchises()));
            }
            catch (FranchiseNotFoundException e)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = e.Message
                });
            }
        }
        /// <summary>
        /// Gets one franchise by ID.
        /// </summary>
        /// <param name="id">Unique identifer for a franchise.</param>
        /// <returns>One specific franchise based on idenfier.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseReadDTO>> GetFranchiseById(int id)
        {
            try
            {
                return Ok(_mapper.Map<FranchiseReadDTO>(await _service.GetFranchiseById(id)));
            }
            catch (FranchiseNotFoundException e)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = e.Message
                });
            }
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
                return Ok(_mapper.Map<IEnumerable<MovieReadDTO>>(await _service.GetAllFranchiseMovies(id)));
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
                return Ok(_mapper.Map<IEnumerable<CharacterReadDTO>>(await _service.GetAllFranchiseCharacters(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
        #region HTTP Posts
        /// <summary>
        /// Create a new franchise in database.
        /// </summary>
        /// <param name="createFranchiseDto">A franchise contains a string Name and a string Description.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Franchise>> CreateFranchise(FranchiseCreateDTO createFranchiseDto)
        {
            try
            {
                var franchise = _mapper.Map<Franchise>(createFranchiseDto);
                await _service.CreateFranchise(franchise);
                return CreatedAtAction(nameof(GetFranchiseById), new { id = franchise.Id }, franchise);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
        #region HTTP Deletes
        /// <summary>
        /// Delete one franchise from database based on a identifier.
        /// </summary>
        /// <param name="id">An unique identifier of a franchise.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            try
            {
                await _service.DeleteFranchise(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }
        #endregion
        #region HTTP Puts
        /// <summary>
        /// Update an existing franchise in database.
        /// </summary>
        /// <param name="id">Unique identifier of a franchise.</param>
        /// <param name="franchiseDTO">An franchise info, Name and description.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, FranchiseUpdateDTO franchiseDTO)
        {
            try
            {
                var franchise = _mapper.Map<Franchise>(franchiseDTO);
                franchise.Id = id;
                await _service.UpdateFranchise(franchise);
            }
            catch (FranchiseNotFoundException e)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = e.Message
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
                await _service.UpdateFranchiseMovies(id, movies);
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("Invalid character.");
            }

            return NoContent();
        }
        #endregion
    }
}
