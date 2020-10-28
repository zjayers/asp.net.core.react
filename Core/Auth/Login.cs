using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dto;
using Core.Errors;
using Core.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

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
            private readonly IJwtGenerator _jwtGenerator;
            private readonly IMapper _mapper;
            private readonly SignInManager<AppUser> _signInManager;
            private readonly UserManager<AppUser> _userManager;

            public Handler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
                IJwtGenerator jwtGenerator, IMapper mapper)
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
                    throw new RestException(HttpStatusCode.Unauthorized, new {activity = "User was null"});


                if (!user.EmailConfirmed)
                    throw new RestException(HttpStatusCode.BadRequest, new {email = "Email is not confirmed"});

                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

                if (!result.Succeeded) throw new RestException(HttpStatusCode.Unauthorized);

                var refreshToken = _jwtGenerator.GenerateRefreshToken();
                user.RefreshTokens.Add(refreshToken);

                await _userManager.UpdateAsync(user);

                return new AppUserDto(user, _jwtGenerator, refreshToken.Token);
            }
        }
    }
}
