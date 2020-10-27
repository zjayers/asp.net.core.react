using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.DTO;
using Core.Events;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EventsController : BaseController
    {
        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetAllActivities(CancellationToken ct)
        {
            return await Mediator.Send(new GetAll.Query(), ct);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<EventDto>> GetOneActivity(Guid id)
        {
            return await Mediator.Send(new GetOne.Query {Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateOneActivity(CreateOne.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("{id}/attend")]
        public async Task<ActionResult<Unit>> CreateOneAttendee(Guid id)
        {
            return await Mediator.Send(new AddAttendee.Command {Id = id});
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "IsActivityHost")]
        public async Task<ActionResult<Unit>> EditOneActivity(Guid id, EditOne.Command command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "IsActivityHost")]
        public async Task<ActionResult<Unit>> DeleteOneActivity(Guid id)
        {
            return await Mediator.Send(new DeleteOne.Command {Id = id});
        }

        [HttpDelete("{id}/attend")]
        public async Task<ActionResult<Unit>> DeleteOneAttendee(Guid id)
        {
            return await Mediator.Send(new RemoveAttendee.Command {Id = id});
        }
    }
}