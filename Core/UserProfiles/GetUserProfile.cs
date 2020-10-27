using System.Threading;
using System.Threading.Tasks;
using Core.Interfaces;
using MediatR;

namespace Core.UserProfiles
{
    public class GetUserProfile
    {
        public class Query : IRequest<UserProfiles.UserProfile>
        {
            public string UserName { get; set; }
        }

        public class Handler : IRequestHandler<Query, UserProfiles.UserProfile>
        {
            private readonly IProfileReader _profileReader;

            public Handler(IProfileReader profileReader)
            {
                _profileReader = profileReader;
            }

            public async Task<UserProfiles.UserProfile> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _profileReader.ReadProfile(request.UserName);
            }
        }
    }
}
