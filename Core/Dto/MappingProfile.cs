using AutoMapper;
using Core.DTO;
using Domain;

namespace Core.Activities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Domain
            CreateMap<Activity, Activity>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<AppUser, AppUser>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Domain to API DTO
            CreateMap<Activity, ActivityDto>()
                .ForMember(dto => dto.Attendees, opt => opt.MapFrom(a => a.UserActivities));

            CreateMap<AppUser, AppUserDto>();
            CreateMap<UserActivity, AttendeeDto>()
                .ForMember(a => a.IsHost, opt => opt.MapFrom(ua => ua.IsHost))
                .ForMember(a => a.UserName, opt => opt.MapFrom(ua => ua.AppUser.UserName))
                .ForMember(a => a.DisplayName, opt => opt.MapFrom(ua => ua.AppUser.DisplayName));


            // API DTO to Domain
            CreateMap<ActivityDto, Activity>();
            CreateMap<AppUserDto, AppUser>();
            CreateMap<AttendeeDto, UserActivity>();
        }
    }
}
