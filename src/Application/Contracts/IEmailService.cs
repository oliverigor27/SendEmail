using SendEmail.Application.DTO;

namespace SendEmail.Application.Contracts;

public interface IEmailService
{
    public Task Send(SendEmailDTO dto);
}
