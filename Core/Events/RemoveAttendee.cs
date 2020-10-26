using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Errors;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Core.Events
{
    public class RemoveAttendee
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

                if (attendance == null)
                    return Unit.Value;

                if (attendance.IsHost)
                    throw new RestException(HttpStatusCode.BadRequest,
                        new {Attendance = "You cannot remove yourself from an event you are hosting."});

                _context.UserEvents.Remove(attendance);

                var numberOfSuccessfulSaves = await _context.SaveChangesAsync();
                var successful = numberOfSuccessfulSaves > 0;

                if (successful) return Unit.Value;

                throw new Exception("Problem saving changes!");
            }
        }
    }
}