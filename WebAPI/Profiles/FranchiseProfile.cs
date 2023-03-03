using AutoMapper;
using Microsoft.Extensions.Options;
using WebAPI.Models;
using WebAPI.Models.DTOs.Franchises;

namespace WebAPI.Profiles
{
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            CreateMap<FranchiseCreateDTO, Franchise>();
            CreateMap<Franchise, FranchiseReadDTO>()
                .ForMember(dto => dto.Movies, options =>
                options.MapFrom(franchiseDomain => franchiseDomain.Movies.Select(movie => $"api/v1/movies/{movie.Id}").ToList()));
            CreateMap<FranchiseUpdateDTO, Franchise>();
        }
    }
}
