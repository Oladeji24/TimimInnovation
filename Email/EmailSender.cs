using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TimimInnovation.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpClient _smtpClient;
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;

            _smtpClient = new SmtpClient(_configuration["EmailSettings:Host"])
            {
                Port = GetIntConfig("EmailSettings:Port"), // Use 465 for SSL if required
                Credentials = new NetworkCredential(
                    _configuration["EmailSettings:Username"],
                    _configuration["EmailSettings:Password"]),
                EnableSsl = GetBoolConfig("EmailSettings:EnableSsl")
            };
        }

        private int GetIntConfig(string key)
        {
            if (int.TryParse(_configuration[key], out int result))
            {
                return result;
            }

            // Handle the case where parsing fails (use a default value or throw an exception)
            throw new InvalidOperationException($"Invalid configuration value for {key}");
        }

        private bool GetBoolConfig(string key)
        {
            if (bool.TryParse(_configuration[key], out bool result))
            {
                return result;
            }

            // Handle the case where parsing fails (use a default value or throw an exception)
            throw new InvalidOperationException($"Invalid configuration value for {key}");
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            try
            {
                var message = new MailMessage
                {
                    From = new MailAddress(_configuration["EmailSettings:From"]),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                message.To.Add(to);

                await _smtpClient.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                // Handle and log the exception (e.g., log to a file or a logging service)
                Console.WriteLine($"Error sending email: {ex.Message}");
                // Optionally rethrow the exception if you want to propagate it further
                // throw;
            }
        }

        public async Task SendEmailAsync(string to, string subject, string body, string from = null, string attachmentFilePath = null)
        {
            try
            {
                var message = new MailMessage
                {
                    From = new MailAddress(from ?? _configuration["EmailSettings:From"]),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                message.To.Add(to);

                if (!string.IsNullOrEmpty(attachmentFilePath))
                {
                    var attachment = new Attachment(attachmentFilePath);
                    message.Attachments.Add(attachment);
                }

                await _smtpClient.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                // Handle and log the exception (e.g., log to a file or a logging service)
                Console.WriteLine($"Error sending email: {ex.Message}");
                // Optionally rethrow the exception if you want to propagate it further
                // throw;
            }
        }
    }
}
