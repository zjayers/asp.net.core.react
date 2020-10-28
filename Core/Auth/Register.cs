using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Errors;
using Core.Interfaces;
using Core.Validators;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Core.Auth
{
    public class Register
    {
        public class Command : AppUser, IEmailVerificationRequest, IRequest
        {
            public string Password { get; set; }
            public string Origin { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.DisplayName).NotEmpty();
                RuleFor(x => x.UserName).NotEmpty();
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                RuleFor(x => x.Password).NotEmpty().AppPassword();
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IEmailSender _emailSender;
            private readonly IMapper _mapper;
            private readonly UserManager<AppUser> _userManager;

            public Handler(DataContext context, IMapper mapper, UserManager<AppUser> userManager, IEmailSender emailSender)
            {
                _context = context;
                _mapper = mapper;
                _userManager = userManager;
                _emailSender = emailSender;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await _context.Users.AnyAsync(x => x.Email == request.Email))
                    throw new RestException(HttpStatusCode.BadRequest, new {Email = "Email already exists"});

                if (await _context.Users.AnyAsync(x => x.UserName == request.UserName))
                    throw new RestException(HttpStatusCode.BadRequest, new {Username = "Username already exists"});

                var user = _mapper.Map<Command, AppUser>(request);

                var result = await _userManager.CreateAsync(user, request.Password);

                if (!result.Succeeded) throw new Exception("Problem creating user!");

                // Setup email confirmation
                await _emailSender.ConstructEmailAndSendAsync(user, request);

                return Unit.Value;
            }
        }
    }
}
