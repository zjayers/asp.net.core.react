using AutoMapper;
using Core.DTO;
using Domain;

namespace Core.Activities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Activity, Activity>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Activity, ActivityDto>();
            CreateMap<ActivityDto, Activity>();
        }
    }
}
