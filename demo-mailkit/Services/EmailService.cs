using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mailkit.Models;
using demo_mailkit.Repositories;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using MimeKit;

namespace demo_mailkit.Services
{
    public class EmailService:IEmailService
    {
        private readonly IEmailConfiguration _emailConfig;
        public EmailService(IEmailConfiguration emailConfiguration)
        {
            _emailConfig = emailConfiguration;
        }

        public async Task<List<EmailMessage>> GetEmails()
        {
            using var emailClient = new ImapClient();
            var username = _emailConfig.ImapUsername;
            var password = _emailConfig.ImapPassword;

            emailClient.Connect(_emailConfig.ImapServer, _emailConfig.ImapPort, true);
            // Note: since we don't have an OAuth2 token, disable
            emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
            emailClient.AuthenticationMechanisms.Remove("NTLM");
            emailClient.Authenticate(username, password);

            var inbox = emailClient.Inbox;
            await inbox.OpenAsync(FolderAccess.ReadWrite);
            List<EmailMessage> messages = new List<EmailMessage>();
            if (inbox.Count > 0)
            {
                foreach (var item in inbox)
                {
                    var emailMessage = new EmailMessage
                    {
                        Id = item.MessageId,
                        Subject = item.Subject,
                        Body = string.IsNullOrEmpty(item.TextBody) ? item.HtmlBody : item.TextBody,
                        Date = item.Date,
                    };
                    emailMessage.ToAddresses.AddRange(item.To.Select(x => (MailboxAddress)x).Select(x => new EmailAddress { Address = x.Address, Name = x.Name }));
                    emailMessage.ToAddresses.AddRange(item.From.Select(x => (MailboxAddress)x).Select(x => new EmailAddress { Address = x.Address, Name = x.Name }));
                    messages.Add(emailMessage);
                }

            }
            emailClient.Disconnect(true);
            return messages;
        }
       
    }
}
