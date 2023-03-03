using AutoMapper;
using Microsoft.Extensions.Options;
using WebAPI.Models;
using WebAPI.Models.DTOs.Franchises;

namespace WebAPI.Profiles
{
    public class FranchiseProfile : Profile
    {
        /// <summary>
        /// Specifies how the AutoMapper should map Franchise objects.
        /// Maps FranchiseCreateDTO to a Franchise object
        /// Maps Franchise object to FranchiseReadDTO and defines a map for the Movies properties of Franchise object to a URL in the format: "api/v1/movies/{movie.Id}"
        /// Maps FranchiseUpdateDTO to a Franchise object.
        /// </summary>
        public FranchiseProfile()
        {
            CreateMap<FranchiseCreateDTO, Franchise>();
            CreateMap<Franchise, FranchiseReadDTO>()
                .ForMember(DTO => DTO.Movies, options =>
                options.MapFrom(franchiseDomain => franchiseDomain.Movies.Select(movie => $"api/v1/movies/{movie.Id}").ToList()));
            CreateMap<FranchiseUpdateDTO, Franchise>();
        }
    }
}
