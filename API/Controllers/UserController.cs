using System;
using System.Threading.Tasks;
using Core.Auth;
using Core.Dto;
using Core.UserProfiles.Facebook;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class UserController : BaseController
    {
        [HttpGet]
        public async Task<AppUserDto> GetCurrentUser()
        {
            return await SendToMediatorAndReturnUser(new CurrentUser.Query());
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AppUserDto>> Login(Login.Query query)
        {
            return await SendToMediatorAndReturnUser(query);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<AppUserDto>> Register(Register.Command command)
        {
            return await SendToMediatorAndReturnUser(command);
        }

        [AllowAnonymous]
        [HttpPost("facebook")]
        public async Task<ActionResult<AppUserDto>> FacebookLogin(ExternalLogin.Query query)
        {
            return await SendToMediatorAndReturnUser(query);
        }

        [HttpPost("refreshToken")]
        public async Task<ActionResult<AppUserDto>> GetRefreshToken(GetRefreshToken.Command command)
        {
            command.RefreshToken = Request.Cookies["refreshToken"];
            return await SendToMediatorAndReturnUser(command);
        }

        private async Task<AppUserDto> SendToMediatorAndReturnUser<T>(T mediatorAction)
        {
            var user = await Mediator.Send(mediatorAction) as AppUserDto;
            SetRefreshTokenCookie(user.RefreshToken);
            return user;
        }

        private void SetRefreshTokenCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions()
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };

            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }
    }
}
