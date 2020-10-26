using System.Threading.Tasks;
using Core.Auth;
using Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    public class UserController : BaseController
    {
        [HttpGet]
        public async Task<AppUserDto> GetCurrentUser()
        {
            return await Mediator.Send(new CurrentUser.Query());
        }

        [HttpPost("login")]
        public async Task<ActionResult<AppUserDto>> Login(Login.Query query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost("register")]
        public async Task<ActionResult<AppUserDto>> Register(Register.Command command)
        {
            return await Mediator.Send(command);
        }
    }
}