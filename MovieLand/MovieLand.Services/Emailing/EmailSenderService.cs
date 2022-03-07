using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MovieLand.Common;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MovieLand.Services.Emailing
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly SendGridClient client;
        public EmailSenderService()
        {
            this.client = new SendGridClient(GlobalConstants.SendGridConfig.SendGridKey);
        }

        public async Task NotifyUser(string userEmail, string subject, string content)
        {
            var from = new EmailAddress(
                GlobalConstants.SendGridConfig.EmailSender, GlobalConstants.SendGridConfig.EmailSenderName);

            var to = new EmailAddress(userEmail);

            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, content);

            await client.SendEmailAsync(msg);
        }
    }
}
