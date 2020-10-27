using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.Errors;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Core.UserProfiles
{
    public class ProfileReader : IProfileReader
    {
        private readonly DataContext _context;
        private readonly IUserAccessor _userAccessor;

        public ProfileReader(DataContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;
        }

        public async Task<UserProfiles.UserProfile> ReadProfile(string username)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);

            if (user == null)
                throw new RestException(HttpStatusCode.NotFound, new {User = "Not found"});

            var currentUser = await _context.Users.SingleOrDefaultAsync(u => u.UserName == _userAccessor.GetCurrentUsername());

            var profile = new UserProfiles.UserProfile()
            {
                UserName = user.UserName,
                DisplayName = user.DisplayName,
                Image = user.Photos.FirstOrDefault(p => p.IsAvatar)?.Url,
                Photos = user.Photos,
                Bio = user.Bio,
                FollowersCount = user.Followers.Count(),
                FollowingCount = user.Followings.Count()
            };

            if (currentUser.Followings.Any(x => x.TargetId == user.Id))
            {
                profile.IsFollowed = true;
            }

            return profile;
        }
    }
}
