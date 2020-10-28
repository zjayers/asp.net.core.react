using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Core.Dto;
using Core.Errors;
using Core.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.Auth
{
    public class GetRefreshToken
    {
        public class Command : IRequest<AppUserDto>
        {
            public string RefreshToken { get; set; }
        }

        public class Handler : IRequestHandler<Command, AppUserDto>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IJwtGenerator _jwtGenerator;
            private readonly IUserAccessor _userAccessor;

            public Handler(UserManager<AppUser> userManager, IJwtGenerator jwtGenerator, IUserAccessor userAccessor)
            {
                _userManager = userManager;
                _jwtGenerator = jwtGenerator;
                _userAccessor = userAccessor;
            }

            public async Task<AppUserDto> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByNameAsync(_userAccessor.GetCurrentUsername());
                var oldToken = user.RefreshTokens.SingleOrDefault(u => u.Token == request.RefreshToken);

                if (oldToken != null && !oldToken.IsActive)
                    throw new RestException(HttpStatusCode.Unauthorized);

                if (oldToken != null)
                {
                    oldToken.Revoked = DateTime.UtcNow;
                }

                var newRefreshToken = _jwtGenerator.GenerateRefreshToken();
                user.RefreshTokens.Add(newRefreshToken);
                await _userManager.UpdateAsync(user);

                return new AppUserDto(user, _jwtGenerator, newRefreshToken.Token);
            }

        }
    }
}
