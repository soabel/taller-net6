using System;
using Microsoft.Extensions.Options;
using todo_api.Configuration;

namespace todo_api.Services
{
	public class EmailService: IEmailService
	{

        //      private readonly IConfiguration _configuration;

        //      public EmailService(IConfiguration configuration)
        //{
        //          _configuration = configuration;
        //}

        private readonly IOptionsSnapshot<EmailSettings> _emailSettings;
            

        public EmailService(IOptionsSnapshot<EmailSettings> emailSettings) {
            _emailSettings = emailSettings;
        }

        public Task Send(string to, string message)
        {

            //var emailServer = _configuration["Email:Server"];

            var server = _emailSettings.Value.Server;

            throw new NotImplementedException();
        }
    }
}

