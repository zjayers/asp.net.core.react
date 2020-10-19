using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : Controller
    {
        private readonly IMediator _mediator;

        public ActivitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> GetAllActivities(CancellationToken ct)
        {
            return await _mediator.Send(new GetAll.Query(), ct);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetOneActivity(Guid id)
        {
            return await _mediator.Send(new GetOne.Query() {Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateOneActivity(CreateOne.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> EditOneActivity(Guid id, EditOne.Command command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> DeleteOneActivity(Guid id, DeleteOne.Command command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }
    }
}
