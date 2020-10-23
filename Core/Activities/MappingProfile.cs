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

            // Domain to API DTO
            CreateMap<Activity, ActivityDto>();

            // API DTO to Domain
            CreateMap<ActivityDto, Activity>();
        }
    }
}
