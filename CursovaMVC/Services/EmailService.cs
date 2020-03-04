using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CursovaMVC.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("andriy23780@gmail.com");
            mail.To.Add(email);
            mail.Subject = "Forgot password";
            mail.IsBodyHtml = true;
            mail.Body = message;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("tmytestmvc@gmail.com", "Qwerty-12121990"),
                EnableSsl = true
            };
            client.Send(mail);
        }
    }
}
