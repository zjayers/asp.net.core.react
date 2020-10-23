using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTO;
using Core.Errors;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Core.Activities
{
    public class EditOne
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

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = _mapper.Map<Command, Activity>(request);

                // Command logic goes here
                var activityInDb = await _context.Activities.FindAsync(activity.Id);

                if (activity == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new {activity = "Could not find activity in database!"});

                _mapper.Map(activity, activityInDb);

                var numberOfSuccessfulySaves = await _context.SaveChangesAsync();
                var successful = numberOfSuccessfulySaves > 0;

                if (successful) return Unit.Value;

                throw new Exception("Problem saving changes!");
            }
        }
    }
}
