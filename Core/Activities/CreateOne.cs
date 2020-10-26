using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTO;
using Core.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Core.Activities
{
    public class CreateOne
    {
        public class Command : ActivityDto, IRequest { }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.Description).NotEmpty();
                RuleFor(x => x.Category).NotEmpty();
                RuleFor(x => x.Date).NotEmpty();
                RuleFor(x => x.City).NotEmpty();
                RuleFor(x => x.Venue).NotEmpty();
            }
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
                var activity = _mapper.Map<Command, Activity>(request);

                _context.Activities.Add(activity);

                var user = await _context.Users.SingleOrDefaultAsync(au => au.UserName == _userAccessor.GetCurrentUsername());

                var attendee = new UserActivity()
                {
                    AppUser = user,
                    Activity = activity,
                    IsHost = true,
                    DateJoined = DateTime.Now
                };

                _context.UserActivities.Add(attendee);

                var numberOfSuccessfulSaves = await _context.SaveChangesAsync();
                var successful = numberOfSuccessfulSaves > 0;

                if (successful) return Unit.Value;

                throw new Exception("Problem saving changes!");
            }
        }
    }
}
