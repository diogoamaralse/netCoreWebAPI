using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;

namespace Demo.API.Services
{
    public class CloudMailService : IMailServices
    {
        private readonly IConfiguration _configuration;
        public CloudMailService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        }
        public void Send(string subject, string message)
        {
            Debug.WriteLine($"Mail from {_configuration["mailSettings:mailToAddress"]} to {_configuration["mailSettings:mailFrom"]}, with CloudMailService.");
            Debug.WriteLine($"Subject: {subject}");
            Debug.WriteLine($"Message: {message}");
        }
    }
}
