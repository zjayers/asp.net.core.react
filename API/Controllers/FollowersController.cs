using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Followers;
using Core.UserProfiles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/profiles")]
    public class FollowersController : BaseController
    {
        [HttpGet("{username}/follow")]
        public async Task<ActionResult<List<UserProfile>>> GetFollowings(string username, string predicate)
        {
            return await Mediator.Send(new GetListOfFollowers.Query {UserName = username, Predicate = predicate});
        }

        [HttpPost("{username}/follow")]
        public async Task<ActionResult<Unit>> AddFollower(string username)
        {
            return await Mediator.Send(new AddFollower.Command() {UserName = username});
        }

        [HttpDelete("{username}/follow")]
        public async Task<ActionResult<Unit>> RemoveFollower(string username)
        {
            return await Mediator.Send(new DeleteFollower.Command() {UserName = username});
        }

    }
}
