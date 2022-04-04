using System;
namespace demo_mailkit.Repositories
{
    public interface IEmailConfiguration
    {
		string ImapServer { get; }
		int ImapPort { get; }
		string ImapUsername { get; }
		string ImapPassword { get; }
	}
}
