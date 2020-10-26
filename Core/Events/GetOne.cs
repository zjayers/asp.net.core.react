using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTO;
using Core.Errors;
using MediatR;
using Persistence;

namespace Core.Events
{
    public class GetOne
    {
        public class Query : IRequest<EventDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, EventDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<EventDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await _context.Events.FindAsync(request.Id);

                if (activity == null)
                    throw new RestException(HttpStatusCode.NotFound,
                        new {activity = "Could not find activity in database!"});

                return _mapper.Map<Domain.Event, EventDto>(activity);
            }
        }
    }
}