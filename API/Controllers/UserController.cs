using System.Threading.Tasks;
using Core.Auth;
using Core.Dto;
using Core.UserProfiles.Facebook;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class UserController : BaseController
    {
        [HttpGet]
        public async Task<AppUserDto> GetCurrentUser()
        {
            return await Mediator.Send(new CurrentUser.Query());
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AppUserDto>> Login(Login.Query query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<AppUserDto>> Register(Register.Command command)
        {
            return await Mediator.Send(command);
        }

        [AllowAnonymous]
        [HttpPost("facebook")]
        public async Task<ActionResult<AppUserDto>> FacebookLogin(ExternalLogin.Query query)
        {
            return await Mediator.Send(query);
        }
    }
}
