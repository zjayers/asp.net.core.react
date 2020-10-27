using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dto;
using Core.Errors;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Core.Comments
{
    public class CreateOneComment
    {
        public class Command : IRequest<CommentDto>
        {
            public string Body { get; set; }
            public Guid EventId { get; set; }
            public string UserName { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Body).NotEmpty();
                RuleFor(x => x.EventId).NotEmpty();
                RuleFor(x => x.UserName).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command, CommentDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CommentDto> Handle(Command request, CancellationToken cancellationToken)
            {

                var activity = await _context.Events.FindAsync(request.EventId);

                if (activity == null)
                    throw new RestException(HttpStatusCode.NotFound, new {Event = "Not found"});

                var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == request.UserName);

                var comment = new Comment()
                {
                    Author = user,
                    Event = activity,
                    Body = request.Body,
                    CreatedAt = DateTime.Now
                };

                activity.Comments.Add(comment);

                var numberOfSuccessfulSaves = await _context.SaveChangesAsync();
                var successful = numberOfSuccessfulSaves > 0;

                if (successful) return _mapper.Map<CommentDto>(comment);

                throw new Exception("Problem saving changes!");
            }
        }
    }
}
