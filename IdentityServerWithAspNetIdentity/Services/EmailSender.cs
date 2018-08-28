//using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechniServIT.MyeID.epoxid.Services
{
    public class EmailSender// : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // empty for now
            await Task.CompletedTask;
        }
    }
}
