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
            CreateMap<Activity, ActivityDto>();
            CreateMap<AppUser, AppUserDto>();

            // API DTO to Domain
            CreateMap<ActivityDto, Activity>();
            CreateMap<AppUserDto, AppUser>();
        }
    }
}
