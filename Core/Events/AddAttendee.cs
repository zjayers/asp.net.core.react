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

namespace Core.Events
{
    public class AddAttendee
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
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
                // Command logic goes here
                var activity = await _context.Events.FindAsync(request.Id);
                if (activity == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new {Activity = "Could not find activity"});

                var user = await _context.Users.SingleOrDefaultAsync(u =>
                    u.UserName == _userAccessor.GetCurrentUsername());
                if (user == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new {Activity = "Could not find user"});

                var attendance = await _context.UserEvents
                    .SingleOrDefaultAsync(ua => ua.ActivityId == activity.Id && ua.AppUserId == user.Id);
                if (attendance != null)
                    throw new RestException(HttpStatusCode.BadRequest,
                        new {Activity = "User is already attending activity"});

                attendance = new UserEvent
                {
                    Event = activity,
                    AppUser = user,
                    IsHost = false,
                    DateJoined = DateTime.Now
                };

                _context.UserEvents.Add(attendance);

                var numberOfSuccessfulSaves = await _context.SaveChangesAsync();
                var successful = numberOfSuccessfulSaves > 0;

                if (successful) return Unit.Value;

                throw new Exception("Problem saving changes!");
            }
        }
    }
}
