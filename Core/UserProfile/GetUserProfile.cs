using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Core.UserProfile
{
    public class GetUserProfile
    {
        public class Query : IRequest<UserProfile>
        {
            public string UserName { get; set; }
        }

        public class Handler : IRequestHandler<Query, UserProfile>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<UserProfile> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == request.UserName);

                return new UserProfile()
                {
                    UserName    = user.UserName,
                    DisplayName = user.DisplayName,
                    Image = user.Photos.FirstOrDefault(p => p.IsAvatar)?.Url,
                    Photos = user.Photos,
                    Bio = user.Bio
                };
            }
        }
    }
}
