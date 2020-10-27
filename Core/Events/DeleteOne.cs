using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dto;
using Core.Errors;
using MediatR;
using Persistence;

namespace Core.Events
{
    public class DeleteOne
    {
        public class Command : EventDto, IRequest { }

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
                var activity = _mapper.Map<Command, Domain.Event>(request);

                var activityInDb = await _context.Events.FindAsync(activity.Id);

                if (activityInDb == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new {activity = "Could not find activity in database!"});

                _context.Remove(activityInDb);

                var numberOfSuccessfulSaves = await _context.SaveChangesAsync();
                var successful = numberOfSuccessfulSaves > 0;

                if (successful) return Unit.Value;

                throw new Exception("Problem saving changes!");
            }
        }
    }
}