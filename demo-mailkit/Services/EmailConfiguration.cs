using System;
using demo_mailkit.Repositories;

namespace demo_mailkit.Services
{
    public class EmailConfiguration : IEmailConfiguration
    {
        public string ImapServer { get; set; }

        public int ImapPort { get; set; }

        public string ImapUsername { get; set; }

        public string ImapPassword { get; set; }
    }
}
