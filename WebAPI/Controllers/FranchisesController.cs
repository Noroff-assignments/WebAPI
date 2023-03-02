using System.Drawing.Drawing2D;
using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Exceptions;
using WebAPI.Models;
using WebAPI.Models.DTOs.Franchises;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseReadDTO>>> GetAllFranchises()
        {
            return Ok(_mapper.Map<IEnumerable<FranchiseReadDTO>>(await _franchiseService.GetAllFranchises()));
        }

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
    }
}
