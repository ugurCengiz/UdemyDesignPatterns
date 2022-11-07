using System;
using System.Net;
using System.Net.Mail;
using BaseProject.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Web.App.Observer.Observer
{
    public class UserObserverSendEmail:IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public UserObserverSendEmail(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void UserCreated(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverSendEmail>>();

            //var mailMessage = new MailMessage();

            //var smptClient = new SmtpClient("smtp.ethereal.email");
            //mailMessage.From = new MailAddress("julie.bailey@ethereal.email");
            ////mailMessage.To.Add(new MailAddress(appUser.Email));
            //mailMessage.To.Add(new MailAddress("julie.bailey@ethereal.email"));
            //mailMessage.Subject = "Sitemize hoş geldiniz";
            //mailMessage.Body = "<p>Sitemizin genel kuralları : ...... </p>";
            //mailMessage.IsBodyHtml = true;


            //smptClient.Port = 587;
            //smptClient.Credentials = new NetworkCredential("julie.bailey@ethereal.email", "Ch7hM7ExH6Wj8qg65Y");
            //smptClient.Send(mailMessage);


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

            logger.LogInformation($"Email was send to user : {appUser.UserName}");

           
        }
    }
}
