using System.Linq;
using AutoMapper;
using Core.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Core.Dto.Resolvers
{
    public class FollowingResolver : IValueResolver<UserEvent, AttendeeDto, bool>
    {
        private readonly IUserAccessor _userAccessor;
        private readonly DataContext _context;

        public FollowingResolver(IUserAccessor userAccessor, DataContext context)
        {
            _userAccessor = userAccessor;
            _context = context;
        }

        public bool Resolve(UserEvent source, AttendeeDto destination, bool destMember, ResolutionContext context)
        {
            var currentUser =
                _context.Users.SingleOrDefaultAsync(u => u.UserName == _userAccessor.GetCurrentUsername()).Result;

            return currentUser.Followings.Any(f => f.TargetId == source.AppUserId);
        }
    }
}
