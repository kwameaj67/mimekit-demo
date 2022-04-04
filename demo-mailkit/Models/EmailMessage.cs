using System;
using System.Collections.Generic;
using Microsoft.Extensions.FileProviders;

namespace demo_mailkit.Models
{
    public class EmailMessage
    {
        public EmailMessage()
        {
            ToAddresses = new List<EmailAddress>();
            FromAddresses = new List<EmailAddress>();
        }
        public string Id { get; set; }
        public List <EmailAddress> ToAddresses { get; set; }
        public List <EmailAddress> FromAddresses { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTimeOffset Date { get; set; }
    }

    // References
    // http://www.mimekit.net/docs/html/N_MailKit_Net_Imap.htm
    // https://csharp.hotexamples.com/examples/MimeKit/MimeMessage/-/php-mimemessage-class-examples.html
    // https://dotnetcoretutorials.com/2017/11/02/using-mailkit-send-receive-email-asp-net-core/
}
