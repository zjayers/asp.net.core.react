using System.Linq;
using AutoMapper;
using Core.DTO;
using Domain;

namespace Core.Dto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Domain
            CreateMap<Domain.Event, Domain.Event>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<AppUser, AppUser>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Domain to API DTO
            CreateMap<Domain.Event, EventDto>()
                .ForMember(dto => dto.Attendees, opt => opt.MapFrom(a => a.UserEvents));

            CreateMap<AppUser, AppUserDto>()
                .ForMember(dto => dto.Image, opt => opt.MapFrom(a => a.Photos
                    .FirstOrDefault(p => p.IsAvatar).Url));

            CreateMap<UserEvent, AttendeeDto>()
                .ForMember(a => a.IsHost, opt => opt.MapFrom(ua => ua.IsHost))
                .ForMember(a => a.UserName, opt => opt.MapFrom(ua => ua.AppUser.UserName))
                .ForMember(a => a.DisplayName, opt => opt.MapFrom(ua => ua.AppUser.DisplayName))
                .ForMember(a => a.Image,
                    opt => opt.MapFrom(au => au.AppUser.Photos.FirstOrDefault(u => u.IsAvatar).Url));


            // API DTO to Domain
            CreateMap<EventDto, Domain.Event>();
            CreateMap<AppUserDto, AppUser>();
            CreateMap<AttendeeDto, UserEvent>();
        }
    }
}
