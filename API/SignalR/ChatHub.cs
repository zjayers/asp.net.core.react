using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Comments;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
    public class ChatHub : Hub
    {
        private readonly IMediator _mediator;

        public ChatHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task SendComment(CreateOneComment.Command command)
        {
            var userName = GetUserName();

            command.UserName = userName;

            var comment = await _mediator.Send(command);

            await Clients.Group(command.EventId.ToString()).SendAsync("ReceiveComment", comment);
        }

        private string GetUserName()
        {
            var userName = Context.User?.Claims?.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;
            return userName;
        }

        // Enable groups to only emit comments to specific activities rather than all
        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
