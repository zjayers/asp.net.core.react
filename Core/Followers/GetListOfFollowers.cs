using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.UserProfiles;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Core.Followers
{
    public class GetListOfFollowers
    {
        public class Query : IRequest<List<UserProfile>>
        {
            public string UserName { get; set; }
            public string Predicate { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<UserProfile>>
        {
            private readonly DataContext _context;
            private readonly IProfileReader _profileReader;

            public Handler(DataContext context, IProfileReader profileReader)
            {
                _context = context;
                _profileReader = profileReader;
            }

            public async Task<List<UserProfile>> Handle(Query request, CancellationToken cancellationToken)
            {
                var queryable = _context.Followings.AsQueryable();
                var userFollowings = new List<UserFollowing>();
                var profiles = new List<UserProfile>();

                switch (request.Predicate)
                {
                    case "followers":
                    {
                        userFollowings =
                            await queryable.Where(x => x.Target.UserName == request.UserName).ToListAsync();

                        foreach (var follower in userFollowings)
                        {
                            profiles.Add(await _profileReader.ReadProfile(follower.Observer.UserName));
                        }

                        break;
                    }

                    case "following":
                    {
                        userFollowings =
                            await queryable.Where(x => x.Observer.UserName == request.UserName).ToListAsync();

                        foreach (var follower in userFollowings)
                        {
                            profiles.Add(await _profileReader.ReadProfile(follower.Target.UserName));
                        }

                        break;
                    }
                }

                return profiles;
            }
        }
    }
}
