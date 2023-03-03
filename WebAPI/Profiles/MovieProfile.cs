using AutoMapper;
using WebAPI.Models;
using WebAPI.Models.DTOs.Movies;

namespace WebAPI.Profiles
{
    public class MovieProfile : Profile
    {
        /// <summary>
        /// Specifies how the AutoMapper should map Movie objects.
        /// Maps MovieCreateDTO to a Movie object
        /// Maps Movie object to MovieReadDTO and defines a map for the Characters properties of a Movie object to a URL in the format: "api/v1/characters/{character.Id}"
        /// Maps MovieUpdateDTO to a Movie object.
        /// </summary>
        public MovieProfile()
        {
            CreateMap<MovieCreateDTO, Movie>();
            CreateMap<Movie, MovieReadDTO>()
                .ForMember(DTO => DTO.Characters, options =>
                options.MapFrom(movieDomain => movieDomain.Characters.Select(character => $"api/v1/characters/{character.Id}").ToList()));
            CreateMap<MovieUpdateDTO, Movie>();
        }
    }
}
