using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTO;
using Domain;
using MediatR;
using Persistence;

namespace Core.Activities
{
    public class DeleteOne
    {
        public class Command : ActivityDto, IRequest { }

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

                var activityInDb = await _context.Activities.FindAsync(activity.Id);

                if (activityInDb == null) throw new Exception("Could not find activity in database!");

                _context.Remove(activityInDb);

                var numberOfSuccessfulySaves = await _context.SaveChangesAsync();
                var successful = numberOfSuccessfulySaves > 0;

                if (successful) return Unit.Value;

                throw new Exception("Problem saving changes!");
            }
        }
    }
}
