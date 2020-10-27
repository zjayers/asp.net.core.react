using System.Threading.Tasks;
using AutoMapper;
using Core.UserProfile;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProfilesController : BaseController
    {
        [HttpGet("{username}")]
        public async Task<ActionResult<UserProfile>> GetProfile(string username)
        {
            return await Mediator.Send(new GetUserProfile.Query() {UserName = username});
        }

        [HttpPut]
        public async Task<ActionResult<Unit>> EditProfile(EditProfile.Command command)
        {
            return await Mediator.Send(command);
        }

    }
}
