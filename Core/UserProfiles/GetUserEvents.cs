using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Core.Dto;
using Core.Errors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Core.UserProfiles
{
    public class GetUserEvents
    {
        public class Query : IRequest<List<UserEventDto>>
        {
            public string UserName { get; set; }
            public string Predicate { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<UserEventDto>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<UserEventDto>> Handle(Query request,
                CancellationToken cancellationToken)
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == request.UserName);

                if (user == null)
                    throw new RestException(HttpStatusCode.NotFound, new { User = "Not found" });

                var queryable = user.UserEvents
                    .OrderBy(a => a.Event.Date)
                    .AsQueryable();

                switch (request.Predicate)
                {
                    case "past":
                        queryable = queryable.Where(a => a.Event.Date <= DateTime.Now);
                        break;
                    case "hosting":
                        queryable = queryable.Where(a => a.IsHost);
                        break;
                    default:
                        queryable = queryable.Where(a => a.Event.Date >= DateTime.Now);
                        break;
                }

                var activities = queryable.ToList();
                var activitiesToReturn = new List<UserEventDto>();

                foreach (var activity in activities)
                {
                    var userActivity = new UserEventDto
                    {
                        Id = activity.Event.Id,
                        Title = activity.Event.Title,
                        Category = activity.Event.Category,
                        Date = activity.Event.Date
                    };

                    activitiesToReturn.Add(userActivity);
                }

                return activitiesToReturn;
            }
        }
    }
}
