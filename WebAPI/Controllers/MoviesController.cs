using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using WebAPI.Exceptions;
using WebAPI.Models;
using WebAPI.Models.DTOs.Characters;
using WebAPI.Models.DTOs.Movies;
using WebAPI.Services.MovieService;

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
    public class MoviesController : ControllerBase
    {
        #region Constructor & Fields
        private readonly IMovieService _service;
        private readonly IMapper _mapper;

        // Sets the service and mapper for this controller via constructor.
        public MoviesController(IMovieService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        #endregion
        #region HTTP Gets
        /// <summary>
        /// Gets all movies from the database via the mapper through an asynchronous call.
        /// </summary>
        /// <returns>All movies in database</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<MovieReadDTO>>(await _service.GetAllMovies()));
            }
            catch (MovieNotFoundException e)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = e.Message
                });
            }
        }

        /// <summary>
        /// Gets a specific movie from the database by ID through an asynchronous call.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Specific movie</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            try
            {
                return Ok(_mapper.Map<MovieReadDTO>(await _service.GetMovieById(id)));
            }
            catch (MovieNotFoundException e)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = e.Message
                });
            }
        }
        /// <summary>
        /// Gets characters in a movie specified by ID.
        /// </summary>
        /// <param name="id">Movie identifier</param>
        /// <returns>Characters in movie</returns>
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<Character>>> GetMovieCharacters(int id)
        {
            try
            { 
                return Ok(_mapper.Map<IEnumerable<CharacterReadDTO>>(await _service.GetAllMovieCharacters(id)));
            }
            catch (MovieNotFoundException e)
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
        /// Updates the values for a, by ID, specified movie.
        /// </summary>
        /// <param name="id">Movie identifier</param>
        /// <param name="movieDTO">Movie DTO</param>
        /// <returns>Movie added to database via Task</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MovieUpdateDTO movieDTO)
        {
            if (id != movieDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                var movie = _mapper.Map<Movie>(movieDTO);
                await _service.UpdateMovie(movie);
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Updates characters in a, by ID, specified movie.
        /// </summary>
        /// <param name="id">Movie identifier</param>
        /// <param name="characters">List of character identifiers</param>
        /// <returns>Updated characters in movie via Task</returns>
        [HttpPut("{id}/characters")]
        public async Task<IActionResult> UpdateMovieCharacters(int id, List<int> characters)
        {
            try
            {
                await _service.UpdateMovieCharacters(id, characters);
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("Invalid character.");
            }

            return NoContent();
        }
        #endregion
        #region HTTP Delete
        /// <summary>
        /// Deletes a movie specified by ID.
        /// </summary>
        /// <param name="id">Movie identifier</param>
        /// <returns>Deletes movie from database via Task</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                await _service.DeleteMovie(id);
            }
            catch (MovieNotFoundException e)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = e.Message
                });
            }

            return NoContent();
        }
        #endregion
    }
}
