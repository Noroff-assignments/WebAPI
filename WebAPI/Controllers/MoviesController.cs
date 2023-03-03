using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using WebAPI.Exceptions;
using WebAPI.Models;
using WebAPI.Models.DTOs.Characters;
using WebAPI.Models.DTOs.Movies;
using WebAPI.Services.MovieService;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _service;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        {
            return Ok(_mapper.Map<IEnumerable<MovieReadDTO>>(await _service.GetAllMovies()));
        }

        /// <summary>
        /// Gets a specific movie from the database by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            try
            {
                return Ok(_mapper.Map<MovieReadDTO>(await _service.GetMovieById(id)));
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        /// <summary>
        /// Updates the values for a, by ID, specified movie.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movieDTO"></param>
        /// <returns></returns>
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
        /// Deletes a movie specified by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                await _service.DeleteMovie(id);
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
        /// <param name="id"></param>
        /// <param name="characters"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets characters in a movie specified by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<Character>>> GetMovieCharacters(int id)
        {
            return Ok(_mapper.Map<IEnumerable<CharacterReadDTO>>(await _service.GetAllMovieCharacters(id)));
        }
    }
}
