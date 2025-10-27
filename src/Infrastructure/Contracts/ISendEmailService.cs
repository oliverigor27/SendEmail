namespace SendEmail.Infrastructure.Contracts;

public interface ISendEmailService
{
    public Task SendEmailAsync(string recipient, string subjetc, string body);
}
