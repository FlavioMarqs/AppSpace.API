using AppSpace.API.Contracts.Requests;
using AppSpace.API.Contracts.Responses;
using AppSpace.Handlers.Commands;
using AppSpace.Handlers.DTOs;
using AppSpace.TMDB.Contracts.Requests;
using AutoMapper;
using System;

namespace AppSpace.RecommendationsService.MappingProfiles
{
    public class RecommendationsMappingProfile : Profile
    {
        public RecommendationsMappingProfile() 
        {
            CreateMap<SmartBillboardRequest, SmartBillboardCommand>()
                .ForMember(d => d.TimeInterval, s => s.MapFrom(o => o.EndTime.Subtract(o.StartTime)))
                .ForMember(d => d.SmallRoomsCount, s => s.MapFrom(o => o.SmallRoomsScreensCount))
                .ForMember(d => d.BigRoomsCount, s => s.MapFrom(o => o.BigRoomsScreensCount));

            CreateMap<SmartBillboardDTO, SmartBillboardResponse>();

            CreateMap<MoviesDiscoverRequest, DiscoverMoviesRequest>();
        }
    }
}
