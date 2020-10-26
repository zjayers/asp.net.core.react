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

            CreateMap<AppUser, AppUserDto>();
            CreateMap<UserEvent, AttendeeDto>()
                .ForMember(a => a.IsHost, opt => opt.MapFrom(ua => ua.IsHost))
                .ForMember(a => a.UserName, opt => opt.MapFrom(ua => ua.AppUser.UserName))
                .ForMember(a => a.DisplayName, opt => opt.MapFrom(ua => ua.AppUser.DisplayName));


            // API DTO to Domain
            CreateMap<EventDto, Domain.Event>();
            CreateMap<AppUserDto, AppUser>();
            CreateMap<AttendeeDto, UserEvent>();
        }
    }
}
