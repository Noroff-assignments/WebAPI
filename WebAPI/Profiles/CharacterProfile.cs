using AutoMapper;
using WebAPI.Models;
using WebAPI.Models.DTOs.Characters;

namespace WebAPI.Profiles
{
    public class CharacterProfile : Profile
    {
        /// <summary>
        /// Specifies how the AutoMapper should map Character objects.
        /// Maps CharacterCreateDTO to a Character object
        /// Maps Character object to CharacterReadDTO and defines a map for the Movies properties of Character object to a URL in the format: "api/v1/movies/{movie.Id}"
        /// Maps CharacterUpdateDTO to a Character object.
        /// </summary>
        public CharacterProfile()
        {
            CreateMap<CharacterCreateDTO, Character>();
            CreateMap<Character, CharacterReadDTO>()
                .ForMember(DTO => DTO.Movies, options =>
                options.MapFrom(characterDomain => characterDomain.Movies.Select(movie => $"api/v1/movies/{movie.Id}").ToList()));
            CreateMap<CharacterUpdateDTO, Character>();
        }
    }
}