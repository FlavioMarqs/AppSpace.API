using AppSpace.Handlers.DTOs;
using AppSpace.Repositories.Entities;
using AutoMapper;

namespace AppSpace.Handlers.MappingProfiles
{
    public class HandlersMappingProfile : Profile
    {
        public HandlersMappingProfile()
        {
            CreateMap<Movie, MovieDTO>();
        }
    }
}
