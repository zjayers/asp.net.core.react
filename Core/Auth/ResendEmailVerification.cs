using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Persistence;

namespace Core.Auth
{
    public class ResendEmailVerification
    {
        public class Query : IEmailVerificationRequest, IRequest
        {
            public string Email { get; set; }
            public string Origin { get; set; }
        }

        public class Handler : IRequestHandler<Query>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IEmailSender _emailSender;


            public Handler(UserManager<AppUser> userManager, IEmailSender emailSender)
            {
                _userManager = userManager;
                _emailSender = emailSender;
            }

            public async Task<Unit> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(request.Email);

                // Setup email confirmation
                await _emailSender.ConstructEmailAndSendAsync(user, request);

                return Unit.Value;
            }
        }
    }
}
