using SendEmail.Application.Contracts;
using SendEmail.Application.DTO;
using SendEmail.Infrastructure.Contracts;

namespace SendEmail.Application.Service;

public class EmailService(ISendEmailService sendEmailService) : IEmailService
{
    public async Task Send(SendEmailDTO dto)
    {
        await sendEmailService.SendEmailAsync(dto.Recipient, dto.Subject, dto.Body);
    }
}
