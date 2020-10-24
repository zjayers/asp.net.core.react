using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTO;
using Core.Errors;
using Core.Interfaces;
using Core.Validators;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistence;

namespace Core.Auth
{
    public class Login
    {
        public class Query : IRequest<AppUserDto>
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Query, AppUserDto>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly SignInManager<AppUser> _signInManager;
            private readonly IJwtGenerator _jwtGenerator;
            private readonly IMapper _mapper;

            public Handler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtGenerator jwtGenerator, IMapper mapper)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _jwtGenerator = jwtGenerator;
                _mapper = mapper;
            }

            public async Task<AppUserDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(request.Email);

                if (user == null)
                {
                    throw new RestException(HttpStatusCode.Unauthorized, new {activity = "User was null"});
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

                if (result.Succeeded)
                {
                    var userDto = _mapper.Map<AppUser, AppUserDto>(user);

                    // Generate the jwt token and return the user
                    userDto.Token = _jwtGenerator.CreateToken(user);
                    return userDto;
                }

                throw new RestException(HttpStatusCode.Unauthorized);
            }
        }
    }
}
