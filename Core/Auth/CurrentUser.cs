using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTO;
using Core.Errors;
using Core.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistence;

namespace Core.Auth
{
    public class CurrentUser
    {
        public class Query : IRequest<AppUserDto> { }

        public class Handler : IRequestHandler<Query, AppUserDto>
        {
            private readonly IMapper _mapper;
            private readonly IJwtGenerator _jwtGenerator;
            private readonly UserManager<AppUser> _userManager;
            private readonly IUserAccessor _userAccessor;


            public Handler(IMapper mapper, IJwtGenerator jwtGenerator, UserManager<AppUser> userManager, IUserAccessor userAccessor)
            {
                _mapper = mapper;
                _jwtGenerator = jwtGenerator;
                _userManager = userManager;
                _userAccessor = userAccessor;
            }

            public async Task<AppUserDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var username = _userAccessor.GetCurrentUsername();
                if (username == null)
                {
                    throw new RestException(HttpStatusCode.Unauthorized);
                }

                var user = await _userManager.FindByNameAsync(username);
                var userDto = _mapper.Map<AppUser, AppUserDto>(user);

                userDto.Token = _jwtGenerator.CreateToken(user);
                return userDto;
            }
        }
    }
}
