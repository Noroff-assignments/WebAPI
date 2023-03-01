using AutoMapper;
using WebAPI.Models;

namespace WebAPI.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<CreateCharacterDTO, Character>();
            CreateMap<Character, ReadCharacterDTO>()
                .ForMember(dto => dto.Movies, options =>
                options.MapFrom(characterDomain => characterDomain.Movies.Select(movie => $"api/v1/movies/{movie.Id}").ToList()));
            CreateMap<UpdateCharacterDTO, Character>();
        }
    }
}