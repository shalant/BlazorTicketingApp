﻿using AutoMapper;
using Ticketing.Entities.DbSet;
using Ticketing.Entities.Dtos.Requests;

namespace Ticketing.API.MappingProfiles;

public class RequestToDomain : Profile
{
    public RequestToDomain()
    {
        CreateMap<CreateDriverAchievementRequest, Achievement>()
            .ForMember(
                dest => dest.RaceWins,
                opt => opt.MapFrom(src => src.Wins))
            .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => true))
            .ForMember(
                dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(
                dest => dest.UpdatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow));
        
        CreateMap<UpdateDriverAchievementRequest, Achievement>()
            .ForMember(
                dest => dest.RaceWins,
                opt => opt.MapFrom(src => src.Wins))
            .ForMember(
                dest => dest.UpdatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<CreateDriverRequest, Driver>()
            .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => true));

        CreateMap<CreateDriverRequest, Driver>()
            .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => true))
            .ForMember(
                dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(
                dest => dest.UpdatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow));
        
        CreateMap<UpdateDriverRequest, Driver>()
            .ForMember(
                dest => dest.UpdatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}
