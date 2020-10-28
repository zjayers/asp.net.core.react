using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Infrastructure.EmailContact
{
    public class EmailSender : IEmailSender
    {
        private readonly IOptions<SendGridSettings> _settings;
        private readonly UserManager<AppUser> _userManager;

        public EmailSender(IOptions<SendGridSettings> settings, UserManager<AppUser> userManager)
        {
            _settings = settings;
            _userManager = userManager;
        }

        public async Task SendEmailAsync(string userEmail, string emailSubject, string message)
        {
            var emailClient = new SendGridClient(_settings.Value.Key);
            var emailMsg = new SendGridMessage()
            {
                From = new EmailAddress("ayers.dev@icloud.com", _settings.Value.User),
                Subject = emailSubject,
                PlainTextContent = message,
                HtmlContent = message
            };

            emailMsg.AddTo(new EmailAddress(userEmail));
            emailMsg.SetClickTracking(false, false);

            await emailClient.SendEmailAsync(emailMsg);
        }

        public async Task ConstructEmailAndSendAsync(AppUser user, IEmailVerificationRequest request)
        {
            var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var queryToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(emailToken));
            var verifyEmailUrl = $"{request.Origin}/user/verifyEmail?token={queryToken}&email={request.Email}";
            var emailHtml =
                $"<p>Please click the link below to verify your email address:</p><a href='{verifyEmailUrl}'>Click To Verify</a>";

            await SendEmailAsync(request.Email, "Lively - Verify Email Address", emailHtml);
        }
    }
}
