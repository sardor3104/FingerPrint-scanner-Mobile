using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Fingerprint
{
    class email
    {
        static void Main(string[] args)
        {
            string fromMail = "sabduhoshimov538@gmail.com";
            string fromPaswd = "";     
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Text faylida yuborilgan xabar";
            message.To.Add(new MailAddress("drahrorov@gmail.com"));
            message.Body = "<html><body>test body </body></html>";
            message.IsBodyHtml = true;
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPaswd),
                EnableSsl = true,
            };
            smtpClient.Send(message);
        }
    }
}
