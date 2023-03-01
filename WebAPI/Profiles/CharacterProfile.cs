using AutoMapper;
using WebAPI.Models;
using WebAPI.Models.DTOs;

namespace WebAPI.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<CharacterCreateDTO, Character>();
            CreateMap<Character, CharacterReadDTO>()
                .ForMember(dto => dto.Movies, options =>
                options.MapFrom(characterDomain => characterDomain.Movies.Select(movie => $"api/v1/movies/{movie.Id}").ToList()));
            CreateMap<CharacterUpdateDTO, Character>();
        }
    }
}