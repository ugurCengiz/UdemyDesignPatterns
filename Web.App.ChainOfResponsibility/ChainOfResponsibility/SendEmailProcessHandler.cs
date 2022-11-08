using System.IO;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;

namespace Web.App.ChainOfResponsibility.ChainOfResponsibility
{
    public class SendEmailProcessHandler:ProcessHandler
    {
        private readonly string _fileName;
        private readonly string _toEmail;

        public SendEmailProcessHandler(string toEmail, string fileName)
        {
            _toEmail = toEmail;
            _fileName = fileName;
        }

        public override object Handle(object o)
        {

            using (MailMessage mail = new MailMessage())
            {
                var zipMemoryStream = o as MemoryStream;
                zipMemoryStream.Position = 0;

                mail.From = new MailAddress("karl.macgyver@ethereal.email");
                mail.To.Add("karl.macgyver@ethereal.email");
                mail.Subject = "Zip dosyası";
                mail.Body = "<p>Zip dosyası ektedir. </p>";

                Attachment attachment = new Attachment(zipMemoryStream,_fileName,MediaTypeNames.Application.Zip);

                mail.Attachments.Add(attachment);


                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.ethereal.email", 587))
                {
                    smtp.Credentials = new NetworkCredential("karl.macgyver@ethereal.email", "GfpCQ9f6DZCBWENgM4");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
            
            return base.Handle(null);
        }
    }
}
