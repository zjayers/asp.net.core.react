using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Core.Events
{
    public class GetAll
    {
        public class Query : IRequest<List<EventDto>> { }

        public class Handler : IRequestHandler<Query, List<EventDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<EventDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activities = await _context.Events.ToListAsync(cancellationToken);

                return _mapper.Map<List<Domain.Event>, List<EventDto>>(activities);
            }
        }
    }
}