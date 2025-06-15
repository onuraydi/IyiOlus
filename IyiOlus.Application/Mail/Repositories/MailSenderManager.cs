using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Core.Mail.Repositories
{
    public class MailSenderManager : IMailSenderRepository
    {
        public async Task SendMailAsync(string toMail,string code)
        {
            var message = new MailMessage
            {
                From = new MailAddress("no-reply@gmail.com", "İyi Oluş"),
                Subject = "Hesap Doğrulama",
                Body = $"<h1>Mail adresinizi doğrulama için kod: {code}</h1>",
                IsBodyHtml=true
            };

            message.To.Add(toMail);

            using var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("yazilimdeneme1934@gmail.com", "bvas mqkk hciw sbwd"),
                EnableSsl=true
            };

            await client.SendMailAsync(message);
        }
    }
}
