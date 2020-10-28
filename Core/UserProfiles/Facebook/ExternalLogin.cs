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
using Persistence;

namespace Core.UserProfiles.Facebook
{
    public class ExternalLogin
    {
        public class Query : IRequest<AppUserDto>
        {
            public string AccessToken { get; set; }
        }

        public class Handler : IRequestHandler<Query, AppUserDto>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IFacebookAccessor _facebookAccessor;
            private readonly IJwtGenerator _jwtGenerator;


            public Handler(UserManager<AppUser> userManager, IFacebookAccessor facebookAccessor,
                IJwtGenerator jwtGenerator)
            {
                _userManager = userManager;
                _facebookAccessor = facebookAccessor;
                _jwtGenerator = jwtGenerator;
            }

            public async Task<AppUserDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var userInfo = await _facebookAccessor.FacebookLogin(request.AccessToken);

                if (userInfo == null)
                    throw new RestException(HttpStatusCode.BadRequest,
                        new {User = "Problem validating Facebook token"});

                var user = await _userManager.FindByEmailAsync(userInfo.Email);

                if (user == null)
                {
                    user = new AppUser()
                    {
                        DisplayName = userInfo.Name,
                        Id = userInfo.Id,
                        Email = userInfo.Email,
                        UserName = "fb_" + userInfo.Id
                    };

                    if (userInfo.ImageData != null)
                    {
                        var photo = new Photo
                        {
                            Id = "fb_" + userInfo.Id,
                            Url = userInfo.ImageData?.Image?.Url,
                            IsAvatar = true
                        };

                        user.Photos.Add(photo);
                    }

                    var result = await _userManager.CreateAsync(user);

                    if (!result.Succeeded)
                        throw new RestException(HttpStatusCode.BadRequest);
                }

                return new AppUserDto()
                {
                    DisplayName = user.DisplayName,
                    Token = _jwtGenerator.CreateToken(user),
                    UserName = user.UserName,
                    Image = user.Photos.FirstOrDefault(x => x.IsAvatar)?.Url
                };
            }
        }
    }
}
