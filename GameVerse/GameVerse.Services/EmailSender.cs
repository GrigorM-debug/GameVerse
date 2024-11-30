using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace GameVerse.Services
{
    /// <summary>
    /// Provides functionality to send emails using the SendGrid service.
    /// </summary>
    public class EmailSender(
        ILogger<EmailSender> logger,
        IConfiguration configuration)
        : IEmailSender
    {
        private readonly ILogger _logger = logger;
        private readonly IConfiguration _configuration = configuration;

        /// <summary>
        /// Sends an email asynchronously using the SendGrid service.
        /// </summary>
        /// <param name="toEmail">The recipient's email address.</param>
        /// <param name="subject">The subject of the email.</param>
        /// <param name="message">The body content of the email, both in plain text and HTML format.</param>
        /// <exception cref="InvalidOperationException">Thrown when the email fails to send.</exception>
        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            IConfiguration sendGridSection = _configuration.GetSection("SendGrid");

            string apiKey = sendGridSection["ApiKey"];

            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("grigormarinov596@gmail.com", subject),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(toEmail));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);
            var response = await client.SendEmailAsync(msg);

            if (!response.IsSuccessStatusCode)
            {
                var errorDetails = await response.Body.ReadAsStringAsync();
                Log.Error($"Failed to send email to {toEmail}. Error: {errorDetails}");
                throw new InvalidOperationException("An error occurred while sending email");
            }
            Log.Information(response.IsSuccessStatusCode
                ? $"Email to {toEmail} queued successfully!"
                : $"Failure Email to {toEmail}");
        }
    }
}
