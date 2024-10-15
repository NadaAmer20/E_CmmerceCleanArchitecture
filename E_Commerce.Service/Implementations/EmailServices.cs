using E_Commerce.Data.Helpers;
using E_Commerce.Service.Abstracts;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
namespace E_Commerce.Service.Implementations
{
    public class EmailServices : IEmailServices
    {
        #region Fields
        private readonly EmailSettings _emailSettings;
        #endregion
        #region Constructors
        public EmailServices(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }

        #endregion
        #region Handle Functions
        public async Task<string> SendEmail(string email, string Message, string? reason)
        {

            try
            {
                // Initialize the SMTP client
                using var client = new MailKit.Net.Smtp.SmtpClient(); // Specify the full namespace
                await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, true);
                client.Authenticate(_emailSettings.FromEmail, _emailSettings.Password);

                // Create the email message
                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = $"{Message}",
                    TextBody = "Welcome"
                };

                var message = new MimeMessage
                {
                    Body = bodyBuilder.ToMessageBody()
                };

                message.From.Add(new MailboxAddress("E-commerce Team", _emailSettings.FromEmail));
                message.To.Add(new MailboxAddress("testing", email));
                message.Subject = reason == null ? "No Submitted" : reason;
                // Send the email
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                return "Success";
            }
            catch (Exception ex)
            {
                // Log the exception (optional) or return a detailed error message
                return $"Failed: {ex.Message}";
            }
        }
        #endregion
    }
}
