using System.Threading.Tasks;
using Domain;

namespace Core.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string userEmail, string emailSubject, string message);

         Task ConstructEmailAndSendAsync(AppUser user, IEmailVerificationRequest request);
    }
}
