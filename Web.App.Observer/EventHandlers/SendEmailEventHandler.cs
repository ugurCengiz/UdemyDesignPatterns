using System.Net.Mail;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Web.App.Observer.Events;
using Web.App.Observer.Observer;

namespace Web.App.Observer.EventHandlers
{
    public class SendEmailEventHandler : INotificationHandler<UserCreatedEvent>
    {
        private readonly ILogger<SendEmailEventHandler> _logger;

        public SendEmailEventHandler(ILogger<SendEmailEventHandler> logger)
        {
            _logger = logger;
        }


        public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {


            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("julie.bailey@ethereal.email");
                mail.To.Add("julie.bailey@ethereal.email");
                mail.Subject = "Sitemize hoş geldiniz"; ;
                mail.Body = "<p>Sitemizin genel kuralları : ...... </p>";
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.ethereal.email", 587))
                {
                    smtp.Credentials = new NetworkCredential("julie.bailey@ethereal.email", "Ch7hM7ExH6Wj8qg65Y");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }

            _logger.LogInformation($"Email was send to user : {notification.AppUser.UserName}");
            return Task.CompletedTask;
        }
    }
}
