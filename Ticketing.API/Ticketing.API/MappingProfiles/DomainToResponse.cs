using AutoMapper;
using Ticketing.Entities.DbSet;
using Ticketing.Entities.Dtos.Requests;
using Ticketing.Entities.Dtos.Responses;

namespace Ticketing.API.MappingProfiles;

public class DomainToResponse : Profile
{
    public DomainToResponse()
    {
        CreateMap<Achievement, DriverAchievementResponse>()
            .ForMember(
                dest => dest.Wins,
                opt => opt.MapFrom(src => src.RaceWins));

        CreateMap<Driver, GetDriverResponse>()
            .ForMember(dest => dest.DriverId,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
    }
}
