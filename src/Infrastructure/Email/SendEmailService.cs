using MimeKit;
using Microsoft.Extensions.Configuration;
using SendEmail.Infrastructure.Contracts;
using MailKit.Net.Smtp;

namespace SendEmail.Infrastructure.Email;

internal sealed class SendEmailService(IConfiguration _configuration) : ISendEmailService
{
    public async Task SendEmailAsync(string recipient, string subjetc, string body)
    {
        var message = CreateEmail(recipient, subjetc, body);
        using var client = new SmtpClient();
        await client.ConnectAsync(
            _configuration["SmtpSettings:Server"], 
            int.Parse(_configuration["SmtpSettings:Port"] ?? string.Empty), 
            MailKit.Security.SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(_configuration["SmtpSettings:Username"], _configuration["SmtpSettings:Password"]);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }

    private MimeMessage? CreateEmail(string toEmail, string subjetc, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_configuration["SmtpSettings:SenderName"], _configuration["SmtpSettings:SenderEmail"]));
        message.To.Add(new MailboxAddress("", toEmail));
        message.Subject = subjetc;
        message.Body = new TextPart("plain") { Text = body };
        return message;
    }
}
