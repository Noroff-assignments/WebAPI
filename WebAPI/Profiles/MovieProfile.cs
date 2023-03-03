using AutoMapper;
using WebAPI.Models;
using WebAPI.Models.DTOs.Movies;

namespace WebAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieCreateDTO, Movie>();
            CreateMap<Movie, MovieReadDTO>()
                .ForMember(DTO => DTO.Characters, options =>
                options.MapFrom(movieDomain => movieDomain.Characters.Select(character => $"api/v1/charachters/{character.Id}").ToList()));
            CreateMap<MovieUpdateDTO, Movie>();
        }
    }
}
