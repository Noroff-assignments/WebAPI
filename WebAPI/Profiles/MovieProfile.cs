﻿using AutoMapper;
using WebAPI.Models;
using WebAPI.Models.DTOs;

namespace WebAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieCreateDTO, Movie>();
            CreateMap<Movie, MovieReadDTO>()
                .ForMember(dto => dto.Characters, options =>
                options.MapFrom(movieDomain => movieDomain.Characters.Select(character => $"api/v1/charachters/{character.Id}").ToList()));
            CreateMap<MovieUpdateDTO, Movie>();
        }
    }
}
