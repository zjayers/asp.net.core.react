using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dto;
using Core.Errors;
using Core.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.Auth
{
    public class CurrentUser
    {
        public class Query : IRequest<AppUserDto> { }

        public class Handler : IRequestHandler<Query, AppUserDto>
        {
            private readonly IJwtGenerator _jwtGenerator;
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;
            private readonly UserManager<AppUser> _userManager;


            public Handler(IMapper mapper, IJwtGenerator jwtGenerator, UserManager<AppUser> userManager,
                IUserAccessor userAccessor)
            {
                _mapper = mapper;
                _jwtGenerator = jwtGenerator;
                _userManager = userManager;
                _userAccessor = userAccessor;
            }

            public async Task<AppUserDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var username = _userAccessor.GetCurrentUsername();
                if (username == null) throw new RestException(HttpStatusCode.Unauthorized);

                var user = await _userManager.FindByNameAsync(username);

                var refreshToken = _jwtGenerator.GenerateRefreshToken();
                user.RefreshTokens.Add(refreshToken);

                await _userManager.UpdateAsync(user);

                return new AppUserDto(user, _jwtGenerator, refreshToken.Token);
            }
        }
    }
}
