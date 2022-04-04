using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mailkit.Models;
using demo_mailkit.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace demo_mailkit.Controllers
{
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        // GET:
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailMessage>>> GetEmailMessages()
        {
            var emails = await _emailService.GetEmails();
            return Ok(emails);
        }

    }
}
