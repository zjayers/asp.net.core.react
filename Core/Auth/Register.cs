using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dto;
using Core.Errors;
using Core.Interfaces;
using Core.Validators;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Core.Auth
{
    public class Register
    {
        public class Command : AppUser, IRequest<AppUserDto>
        {
            public string Password { get; set; }
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

        public class Handler : IRequestHandler<Command, AppUserDto>
        {
            private readonly DataContext _context;
            private readonly IJwtGenerator _jwtGenerator;
            private readonly IMapper _mapper;
            private readonly UserManager<AppUser> _userManager;

            public Handler(DataContext context, IMapper mapper, UserManager<AppUser> userManager,
                IJwtGenerator jwtGenerator)
            {
                _context = context;
                _mapper = mapper;
                _userManager = userManager;
                _jwtGenerator = jwtGenerator;
            }

            public async Task<AppUserDto> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await _context.Users.AnyAsync(x => x.Email == request.Email))
                    throw new RestException(HttpStatusCode.BadRequest, new {Email = "Email already exists"});

                if (await _context.Users.AnyAsync(x => x.UserName == request.UserName))
                    throw new RestException(HttpStatusCode.BadRequest, new {Username = "Username already exists"});

                var user = _mapper.Map<Command, AppUser>(request);

                var refreshToken = _jwtGenerator.GenerateRefreshToken();
                user.RefreshTokens.Add(refreshToken);

                var result = await _userManager.CreateAsync(user, request.Password);

                if (!result.Succeeded) throw new Exception("Problem creating user!");

                return new AppUserDto(user, _jwtGenerator, refreshToken.Token);
            }
        }
    }
}
