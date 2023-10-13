using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Shared;
using SEDC.Lamazon.ViewModels.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailOptions;

        public EmailService(IOptions<EmailConfiguration> emailOptions)
        {
            _emailOptions = emailOptions.Value;
        }

        public void SendEmail(EmailViewModel emailViewModel)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_emailOptions.Username));
            email.To.Add(MailboxAddress.Parse(emailViewModel.To));
            email.Subject = emailViewModel.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = emailViewModel.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_emailOptions.SmtpServer, _emailOptions.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_emailOptions.Username, _emailOptions.Password);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
