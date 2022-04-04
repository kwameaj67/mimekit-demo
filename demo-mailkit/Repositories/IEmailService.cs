using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using demo_mailkit.Models;

namespace demo_mailkit.Repositories
{
    public interface IEmailService
    {
        Task <List<EmailMessage>> GetEmails();
    }
}
