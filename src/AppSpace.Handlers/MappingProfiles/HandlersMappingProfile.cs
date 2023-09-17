using AppSpace.Handlers.DTOs;
using AppSpace.Repositories.Entities;
using AppSpace.TMDB.Contracts.Responses;
using AutoMapper;
using System;

namespace AppSpace.Handlers.MappingProfiles
{
    public class HandlersMappingProfile : Profile
    {
        public HandlersMappingProfile()
        {
            CreateMap<Movie, MovieDTO>();

            CreateMap<TMDBMovieResponse, MovieDTO>()
                .ForMember(d => d.Adult, s => s.MapFrom(o => o.IsAdultRated))
                .ForMember(d => d.ReleaseDate, s => s.MapFrom(o => DateTime.Parse(o.ReleaseDate)))
                .ForMember(d => d.OriginalTitle, s => s.MapFrom(o => o.OriginalTitle))
                .ForMember(d => d.Id, s => s.MapFrom(o => o.Identifier))
                .ForMember(d => d.OriginalLanguage, s => s.MapFrom(o => o.Language))
                .ForAllMembers(d => d.Ignore());

        }
    }
}
