using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Errors;
using Core.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Core.Followers
{
    public class AddFollower
    {
        public class Command : IRequest
        {
            public string UserName { get; set; }
        }

        public class Handler : IRequestHandler<Command>

        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
            {
                _context = context;
                _mapper = mapper;
                _userAccessor = userAccessor;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {

                var observer =
                    await _context.Users.SingleOrDefaultAsync(u => u.UserName == _userAccessor.GetCurrentUsername());

                var target = await _context.Users.SingleOrDefaultAsync(u => u.UserName == request.UserName);

                if (target == null)
                    throw new RestException(HttpStatusCode.NotFound, new {User = "Not found"});

                var following =
                    await _context.Followings.SingleOrDefaultAsync(f =>
                        f.ObserverId == observer.Id && f.TargetId == target.Id);

                if (following != null)
                    throw new RestException(HttpStatusCode.BadRequest, new {User = "You are already following this user."});

                following = new UserFollowing()
                {
                    Observer = observer,
                    Target = target
                };

                _context.Followings.Add(following);

                var numberOfSuccessfulSaves = await _context.SaveChangesAsync();
                var successful = numberOfSuccessfulSaves > 0;

                if (successful) return Unit.Value;

                throw new Exception("Problem saving changes!");
            }
        }
    }
}
