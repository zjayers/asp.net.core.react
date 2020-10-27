using System.Linq;
using AutoMapper;
using Core.Dto.Resolvers;
using Domain;

namespace Core.Dto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Domain
            CreateMap<Event, Event>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<AppUser, AppUser>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Domain to API DTO
            CreateMap<Event, EventDto>()
                .ForMember(dto => dto.Attendees, opt => opt.MapFrom(a => a.UserEvents));

            CreateMap<AppUser, AppUserDto>()
                .ForMember(dto => dto.Image, opt => opt.MapFrom(a => a.Photos
                    .FirstOrDefault(p => p.IsAvatar).Url));

            CreateMap<UserEvent, AttendeeDto>()
                .ForMember(dto => dto.IsHost, opt => opt.MapFrom(ua => ua.IsHost))
                .ForMember(dto => dto.UserName, opt => opt.MapFrom(ua => ua.AppUser.UserName))
                .ForMember(dto => dto.DisplayName, opt => opt.MapFrom(ua => ua.AppUser.DisplayName))
                .ForMember(dto => dto.Image,
                    opt => opt.MapFrom(au => au.AppUser.Photos.FirstOrDefault(u => u.IsAvatar).Url))
                .ForMember(dto => dto.Following, opt => opt.MapFrom<FollowingResolver>());

            CreateMap<Comment, CommentDto>()
                .ForMember(dto => dto.UserName, opt => opt.MapFrom(u => u.Author.UserName))
                .ForMember(dto => dto.DisplayName, opt => opt.MapFrom(u => u.Author.DisplayName))
                .ForMember(d => d.Image, opt => opt.MapFrom(s => s.Author.Photos.FirstOrDefault(x => x.IsAvatar).Url));


            // API DTO to Domain
            CreateMap<EventDto, Event>();
            CreateMap<AppUserDto, AppUser>();
            CreateMap<AttendeeDto, UserEvent>();
            CreateMap<CommentDto, Comment>();
        }
    }
}
