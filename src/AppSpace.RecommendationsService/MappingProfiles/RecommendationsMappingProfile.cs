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
                .ForMember(d => d.BigRoomsCount, s => s.MapFrom(o => o.BigRoomsScreensCount))
                .ForMember(d => d.Filters, s => s.MapFrom(o => o.Filters.ToDictionary(1)));

            CreateMap<SmartBillboardRequest, ComparisonCommand>()
             .ForMember(d => d.TimeInterval, s => s.MapFrom(o => o.EndTime.Subtract(o.StartTime)))
             .ForMember(d => d.SmallRoomsCount, s => s.MapFrom(o => o.SmallRoomsScreensCount))
             .ForMember(d => d.BigRoomsCount, s => s.MapFrom(o => o.BigRoomsScreensCount))
             .ForMember(d => d.Filters, s => s.MapFrom(o => o.Filters.ToDictionary(1)));

            CreateMap<SmartBillboardRequest, SmartBillboardQuery>()
                .ForMember(d => d.SmallRoomsCount, s => s.MapFrom(o => o.SmallRoomsScreensCount))
                .ForMember(d => d.BigRoomsCount, s => s.MapFrom(o => o.BigRoomsScreensCount))
                .ForMember(d => d.TimeInterval, s => s.MapFrom(o => o.EndTime.Subtract(o.StartTime)));

            CreateMap<Handlers.DTOs.MovieDTO, API.Contracts.DTOs.MovieDTO>();
            CreateMap< Handlers.DTOs.Week<Handlers.DTOs.MovieDTO>, API.Contracts.DTOs.WeekDTO<API.Contracts.DTOs.MovieDTO>>();

            CreateMap<SmartBillboardDTO, SmartBillboardResponse>()
                .ForMember(d => d.SmallRoomMovies, s => s.MapFrom(o => o.SmallRoomMovies))
                .ForMember(d => d.BigRoomMovies, s => s.MapFrom(o => o.BigRoomMovies));

            CreateMap<MoviesDiscoverRequest, DiscoverMoviesRequest>();
        }
    }
}
