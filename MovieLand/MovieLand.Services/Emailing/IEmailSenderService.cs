using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieLand.Services.Emailing
{
    public interface IEmailSenderService
    {
        public Task NotifyUser(string userEmail, string subject, string content);
    }
}
