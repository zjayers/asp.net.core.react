using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dto;
using Core.UserProfiles;
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

        [HttpGet("{username}/events")]
        public async Task<ActionResult<IEnumerable<UserEventDto>>> GetUserEvents(string username, string predicate)
        {
            return await Mediator.Send(new GetUserEvents.Query() {UserName = username, Predicate = predicate});
        }

        [HttpPut]
        public async Task<ActionResult<Unit>> EditProfile(EditProfile.Command command)
        {
            return await Mediator.Send(command);
        }

    }
}
