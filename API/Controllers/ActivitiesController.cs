using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Activities;
using Core.DTO;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseController
    {
        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityDto>>> GetAllActivities(CancellationToken ct)
        {
            return await Mediator.Send(new GetAll.Query(), ct);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ActivityDto>> GetOneActivity(Guid id)
        {
            return await Mediator.Send(new GetOne.Query() {Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateOneActivity(CreateOne.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> EditOneActivity(Guid id, EditOne.Command command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> DeleteOneActivity(Guid id)
        {
            return await Mediator.Send(new DeleteOne.Command(){Id = id});
        }
    }
}
