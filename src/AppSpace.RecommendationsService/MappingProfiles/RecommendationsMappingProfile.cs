using AppSpace.API.Contracts.Requests;
using AppSpace.API.Contracts.Responses;
using AppSpace.Handlers.Commands;
using AppSpace.Handlers.Interfaces;
using AutoMapper;
using System;

namespace AppSpace.RecommendationsService.MappingProfiles
{
    public class RecommendationsMappingProfile : Profile
    {
        public RecommendationsMappingProfile() 
        {
            CreateMap<ISmartBillboardRequest, SmartBillboardCommand>()
                .ForMember(d => d.StartDate, s => s.MapFrom(o => o.StartTime))
                .ForMember(d => d.EndDate, s => s.MapFrom(o => o.EndTime))
                .ForMember(d => d.SmallRoomsCount, s => s.MapFrom(o => o.SmallRoomsScreensCount))
                .ForMember(d => d.BigRoomsCount, s => s.MapFrom(o => o.BigRoomsScreensCount));

            CreateMap<ISmartBillboardDTO, SmartBillboardResponse>();
        }
    }
}
