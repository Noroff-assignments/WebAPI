using AutoMapper;
using WebAPI.Models;

namespace WebAPI.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<CreateCharacterDto, Character>();
            CreateMap<Character, ReadCharacterDto>()
                .ForMember(dto => dto.Movies, options =>
                options.MapFrom(characterDomain => characterDomain.Movies.Select(movie => $"api/v1/movies/{movie.Id}").ToList()));
            CreateMap<UpdateCharacterDto, Character>();
        }
    }
}